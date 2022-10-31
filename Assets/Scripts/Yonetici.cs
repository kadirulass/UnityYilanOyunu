using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Yonetici : MonoBehaviour
{
    public bool PanelController = false;
    public bool _PanelCtrl = false;
    public List<GameObject> Levels;
   public GameObject Level;
 //   public int levelnum;
    public string tur;
    public int levelindex = -1;

    public GameObject Menu;
    public GameObject ilkMenu;

    public GameObject Pause;
    public GameObject Resume;


    public TextMeshProUGUI skor_txt;
    public yilans yilan;

    int sayac = 0;
    menu m;

    public GameObject sahne1;
    public GameObject sahne2;
    public GameObject sahne3;
    public GameObject sahne5;

    public List<Sprite> Yems;


    public GameObject progressBar;

    public Slider slider;

    public scrolScript _scrolScript;

    void Start()
    {
        Time.timeScale = 0f;

        if (tur == "level")
        {
        creatNewLevel(); 
        }
    }
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            /*if (sayac % 2 == 0) {
                Time.timeScale = 0.0f;
                Menu.SetActive(true);
                skor_txt.text = yilan.getSkor();
                PanelController = true;
            }
            else
            {
                Time.timeScale = 1.0f;
                Menu.SetActive(false);
                PanelController = false;
                skor_txt.text = yilan.getSkor();
            }
            sayac++;*/
            Application.Quit();
        }

        Time.timeScale = PanelController ? 0f : 1f;
    }


    public void creatNewLevel()
    {
        if (Level != null)
        { Destroy(Level); }
     
        if(Levels.Count> levelindex)
        Level = Instantiate(Levels[levelindex], new Vector3(0, 0, 0), Quaternion.identity);

        else if (Levels.Count == levelindex)
        {
            PanelController = true;
            levelindex = 0;
            _PanelCtrl = false;
            _scrolScript.ScoreControl(yilan.GetComponent<yilans>().skor1);
        }
    }

    public void BtnYeniden()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        sahne1.SetActive(false);
        Menu.SetActive(false);
        Time.timeScale = 1.0f;

        switch (tur)
        {
            case "sýnýrsýz":
                freestartGame();
                break;
            case "level":
                LEVELstartGame();
                break;

            case "teklevel":
                BtnHome();
                break;
            
        }
    }
    public void BtnHome()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Menu.SetActive(false);
        sahne1.SetActive(true);
    }
    public void freestartGame()
    {
        tur = "sýnýrsýz";
        ilkMenu.SetActive(false);
        Time.timeScale = 1.0f;
        progressBar.SetActive(false);

    }
    public void LEVELstartGame()
    {
        tur = "level";
        sahne2.SetActive(false);
        progressBar.SetActive(true);
        levelindex++;
        creatNewLevel();
        Time.timeScale = 1.0f;
    }
    public void kutuLEVELstartGame()
    {
        tur = "teklevel";
        levelindex = 0;
        sahne2.SetActive(false);
        Time.timeScale = 1.0f;
        creatNewLevel();
    }
    public void LLEVELstartGame()
    {
        tur = "teklevel";
        levelindex = 1;
        sahne2.SetActive(false);
        Time.timeScale = 1.0f;
        creatNewLevel();
    }
    public void DLEVELstartGame()
    {
        tur = "teklevel";
        levelindex = 2;
        sahne2.SetActive(false);
        Time.timeScale = 1.0f;
        creatNewLevel();
    }
    public void ApLEVELstartGame()
    {
        tur = "teklevel";
        levelindex = 3;
        sahne2.SetActive(false);
        Time.timeScale = 1.0f;
        creatNewLevel();
    }
    public void MixLEVELstartGame()
    {
        tur = "teklevel";
        levelindex = 4;
        sahne2.SetActive(false);
        Time.timeScale = 1.0f;
        creatNewLevel();
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
    public void geri3()
    {
        sahne1.SetActive(true);
        sahne5.SetActive(false);
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


    public void gameScreen()
    {

        ilkMenu.SetActive(true);
       
    }
    public void settings()
    {
        sahne1.SetActive(false);
        sahne5.SetActive(true);
    }
    public void save_setting()
    {
        yilan.timer2 = (float)((10 - slider.value)/100);
        sahne1.SetActive(true);
        sahne5.SetActive(false);
    }
    public void cikisYap()
    {
        Application.Quit();
    }
   
}
