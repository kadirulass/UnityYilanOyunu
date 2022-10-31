using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class menu : MonoBehaviour
{
    public GameObject sahne1;
    public GameObject sahne2;
    public GameObject sahne3;
    public yilans yonet;
    public TextMeshProUGUI hightskor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {  
      //  hightskor.text = "SKOR: " + yonet.GetComponent<yilans>().skor1.ToString();
        
    }
    public void sahnedegis()
    {
        sahne1.SetActive(false);
        sahne2.SetActive(true);
    }
    public void geri()
    {
        sahne1.SetActive(true);
        sahne2.SetActive(false);
    }
    public void geri2()
    {
        sahne1.SetActive(true);
        sahne3.SetActive(false);
    }
public void hightSccore()
    {
        sahne1.SetActive(false);
        sahne3.SetActive(true);
      
    }
    public void sinirsizLevel()
    {
        SceneManager.LoadScene(1);
    }
}
