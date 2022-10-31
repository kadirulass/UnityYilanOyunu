using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class yilans : MonoBehaviour
{
    public float timer1, yilanEni;
    public float timer2;
    private string hareket,hareket2;
    public GameObject yem,kuyruk,yemB;
    [HideInInspector]
    public GameObject seftali;
    AudioSource audioSource;
    public int topKuyruk;
    [HideInInspector]
    public Vector3[] yilanKuyruk;
    public bool kuyrukolusum;

    public int YilanSize;

    float x = 9;
    float y = 5;
    [HideInInspector]
    public int skor1 = 0;

    public List<AudioClip> Aclip;

    public List<GameObject> YilanYon;

    Yonetici yonetici;

    public scrolScript _ScrolScript;

    List<GameObject> kuyrukList;

    void Start()
    {
        kuyrukList = new List<GameObject>();
        kuyrukolusum = false;
        transform.position = new Vector3(0, 0, transform.position.z);
        audioSource = GameObject.Find("Yonetici").GetComponent<AudioSource>();
        timer2 /= 100;
        getSkor();
        yilanEni = gameObject.GetComponent<SpriteRenderer>().size.x;
        YilanSize = 1000;
        yilanKuyruk = new Vector3[YilanSize];

    //    skor1 = PlayerPrefs.HasKey("skor") ? PlayerPrefs.GetInt("skor") : 0;


     
        yonetici = GameObject.Find("Yonetici").GetComponent<Yonetici>();
    }


    void Update()
    {
       
        if (transform.position.x > x)
        {
            transform.position = new Vector3(-x, transform.position.y, transform.position.z);
        }
        if (transform.position.x <-x)
        {
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
        }
        if (transform.position.y > y)
        {
            transform.position = new Vector3(transform.position.x, -y, transform.position.z);
        }
        if (transform.position.y < -y)
        {
            transform.position = new Vector3(transform.position.x, y, transform.position.z);
        }

        yemler();
       

        if (Input.GetKey("w") || Input.GetKey("up"))
        {
           
            if (hareket2 != "down")
            {
                 YilanList();
                YilanYon[0].SetActive(true);
                hareket = "up";
            }
            this.GetComponent<SpriteRenderer>().sprite = null;
        }
        if (Input.GetKey("s") || Input.GetKey("down"))
        {
            
            if (hareket2 != "up")
            {YilanList();
            YilanYon[1].SetActive(true);
                hareket = "down";
            }
            this.GetComponent<SpriteRenderer>().sprite = null;
        }
        if (Input.GetKey("a") || Input.GetKey("left"))
        {
           
            if (hareket2 != "right")
            { YilanList();
            YilanYon[3].SetActive(true);
                hareket = "left";
            }
            this.GetComponent<SpriteRenderer>().sprite = null;
        }
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
          
            if (hareket2 != "left")
            {  YilanList();
            YilanYon[2].SetActive(true);
                hareket = "right";
            }
            this.GetComponent<SpriteRenderer>().sprite = null;
        }
        sagsol();
        

    }
    private void sagsol()
    {
       
        if (Time.time > timer1)
        {  
            yilanKuyruk[0] = transform.position;
            for(int i = 0; i < topKuyruk ; i++)
            {
                yilanKuyruk[topKuyruk-i] = yilanKuyruk[topKuyruk-1-i];
            }

       

            if (hareket == "right")
            {
                hareket2 = hareket;
                transform.position = new Vector3(transform.position.x + yilanEni, transform.position.y + transform.position.z);
            
            }
            if (hareket == "left")
            {
                hareket2 = hareket;
                transform.position = new Vector3(transform.position.x - yilanEni, transform.position.y + transform.position.z);
            }
            if (hareket == "up")
            {
                hareket2 = hareket;
                transform.position = new Vector3(transform.position.x, transform.position.y + yilanEni + transform.position.z);
            }
            if (hareket == "down")
            {
                hareket2 = hareket;
                transform.position = new Vector3(transform.position.x, transform.position.y - yilanEni + transform.position.z);
            }
            if (kuyrukolusum == true)
            {
                hareket2 = hareket;
               GameObject t = Instantiate(kuyruk, transform.position, Quaternion.identity);
                kuyrukolusum = false;
                kuyrukList.Add(t);


            }
            timer1 = timer2 + Time.time;
        }

    }
    private void yemler()
    {
        if (GameObject.FindGameObjectWithTag("yem") == null)
        {

            Instantiate(yem, new Vector3(Random.Range(-8, 9), Random.Range(-4, 5), yem.transform.position.z), Quaternion.identity);

            if (skor1 > 0 && skor1 % 40 == 0)
            {

                audioSource.PlayOneShot(Aclip[2]);
                Instantiate(yemB, new Vector3(Random.Range(-8, 9), Random.Range(-4, 5), yem.transform.position.z), Quaternion.identity);
            }

        }
    }
 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag =="engel")
        {
            yonetici.GetComponent<Yonetici>().levelindex = 0;
            yonetici.GetComponent<Yonetici>().PanelController = true;
            yonetici.skor_txt.text = getSkor();
            audioSource.PlayOneShot(Aclip[1]);
            Time.timeScale = 0.0f;
            _ScrolScript.ScoreControl(skor1);

        }
    }

    void YilanList()
    {
        if(yonetici._PanelCtrl)
        {
            yonetici.PanelController = false;
            yonetici._PanelCtrl = false;
        }
       
        foreach (GameObject item in YilanYon)
        {
            item.SetActive(false);
        }
    }
  
    public void DestroyKuyruk()
    {
        foreach (GameObject item in kuyrukList)
            Destroy(item);
    }
    
    public string getSkor()
    {
        string sf = "";
        for (int i = 0; i < 7 - skor1.ToString().Length; i++)
            sf += "0";
        sf += skor1.ToString();
        return "SKOR: " + sf;
    }
}
