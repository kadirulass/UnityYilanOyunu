using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class kuyrukyapma : MonoBehaviour
{
    private GameObject yilan;
    Yonetici yonetici;
    private int kuyrukno;
    public TextMeshProUGUI skor_txt;
    bool kntrl;
    AudioSource audioSource;
    bool sc = false;
    scrolScript _ScrolScript;
    void Start()
    {
        kntrl = false;
        yilan = GameObject.Find("yýlan");
        kuyrukno = yilan.GetComponent<yilans>().topKuyruk;
        audioSource = GameObject.Find("Yonetici").GetComponent<AudioSource>();
        yonetici = GameObject.Find("Yonetici").GetComponent<Yonetici>();

        _ScrolScript = yilan.GetComponent<yilans>()._ScrolScript;


    }

    
    void Update()
    {
        if (kntrl == true)
        {
            if (new Vector2(transform.position.x, transform.position.y) == new Vector2(yilan.transform.position.x, yilan.transform.position.y))
            {
                yonetici.skor_txt.text = yilan.GetComponent<yilans>().getSkor();
                Time.timeScale = 0.0f;
                yonetici.PanelController = true;
                if (!sc)
                { 
                    audioSource.PlayOneShot(yilan.GetComponent<yilans>().Aclip[1]);
                    _ScrolScript.ScoreControl(yilan.GetComponent<yilans>().skor1);
                    sc = true;
                }
            }
        }
        else
        {
            kntrl = true;
        }
        transform.position = yilan.GetComponent<yilans>().yilanKuyruk[kuyrukno];
    }
}
