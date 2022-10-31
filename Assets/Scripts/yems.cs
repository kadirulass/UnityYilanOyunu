using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class yems : MonoBehaviour
{
    private GameObject yilan;
    TextMeshProUGUI skor;
    Image pb;
    AudioSource audioSource;
    Yonetici yonetici;
    yilans yln;
    bool YemCtrl = false;

    void Start()
    {
        skor = GameObject.Find("Canvas/skor").GetComponent<TextMeshProUGUI>();
        yilan = GameObject.Find("yýlan");
        skor.text = yilan.GetComponent<yilans>().getSkor();
    
        audioSource = GameObject.Find("Yonetici").GetComponent<AudioSource>();
        yonetici = GameObject.Find("Yonetici").GetComponent<Yonetici>();
        yln = GameObject.Find("yýlan").GetComponent<yilans>();

        if (gameObject.tag == "Yem")
        {
            InvokeRepeating("YanSon", 0.0f, 0.5f);
            Invoke("iptalEt", 5.0f);
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "snake")
        {
            yemYeme();


            if (gameObject.tag == "yem")
            {
                yilan.GetComponent<yilans>().skor1+=5;
                audioSource.PlayOneShot(yilan.GetComponent<yilans>().Aclip[0]);

            }

            else if (gameObject.tag == "Yem")
            {
                yilan.GetComponent<yilans>().skor1 += 10;
                audioSource.PlayOneShot(yilan.GetComponent<yilans>().Aclip[3]);
            }

            skor.text =  yilan.GetComponent<yilans>().getSkor();

            if (yonetici.tur == "level")
            {
                pb = GameObject.Find("Canvas/progresbar/value").GetComponent<Image>();
                if (pb.fillAmount < 1)
                {


                    if (gameObject.tag == "yem")
                        pb.fillAmount += 0.05f;
                    else if (gameObject.tag == "Yem")
                    {
                        pb.fillAmount += 0.1f;

                    }

                }
                else
                {
                    pb.fillAmount = 0.0f;
                    yonetici.GetComponent<Yonetici>().levelindex++;
                    yonetici.GetComponent<Yonetici>().PanelController = true;
                    yonetici.GetComponent<Yonetici>()._PanelCtrl = true;
                      yonetici.GetComponent<Yonetici>().creatNewLevel();
                    Time.timeScale = 0.0f;
                    yilan.GetComponent<yilans>().DestroyKuyruk();
                    yilan.transform.position = new Vector2(0, 0);
                    yilan.GetComponent<yilans>().topKuyruk = 0;

                }
            }
           
            Destroy(this.gameObject);
        
        }
        if (collision.gameObject.tag == "engel")
        {
         
            Destroy(this.gameObject);
            
        }
    }

    void YanSon()
    {
        if (YemCtrl)
        {
            this.GetComponent<SpriteRenderer>().sprite = yonetici.GetComponent<Yonetici>().Yems[0];
            YemCtrl = false;
        }
        else
        {

            this.GetComponent<SpriteRenderer>().sprite = yonetici.GetComponent<Yonetici>().Yems[1];
            YemCtrl = true;
        }
    }
    void iptalEt()
    {
        if (gameObject.tag == "Yem")
        {
            Destroy(this.gameObject);
        }
    }

    public void yemYeme()
    {
        if (yln.topKuyruk < yln.YilanSize - 1)
        {
                yln.topKuyruk += 1;  
        }
        yln.kuyrukolusum = true;


    }

}
