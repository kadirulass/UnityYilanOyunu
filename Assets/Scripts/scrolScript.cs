using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scrolScript : MonoBehaviour
{
    public GameObject prefab;
 

    public  List<int> scorelist;
    public  List<string> nameslist;

    public  GameObject Panel;

    public  InputField name;

    public  TextMeshProUGUI skor;
  public  Yonetici yonet;

    

    void Start()
    {
        getData();
        pop();
    }

 void pop()
    {
      
        for (int i = 0; i < scorelist.Count; i++)
        {
             GameObject _game =(GameObject) Instantiate(prefab,transform);
            if (scorelist[i] != -1)
            _game.GetComponent<TextMeshProUGUI>().text = (i+1)+". "+nameslist[i] + " : " + scorelist[i];
        }
    }

    public  void ScoreControl(int score)
    {
        getData();

        if (scorelist[scorelist.Count-1] < score && score > 0)
        {//listeye girmeye hak kazandý

            Panel.SetActive(true);
            skor.text = "SKOR : " + score;

            scorelist.RemoveAt(scorelist.Count - 1);
            scorelist.Add(score);
            
        }
        else
        {
            yonet.Menu.SetActive(true);
          
        }
    }
   
    public void BtnKaydet()
    {
        nameslist.RemoveAt(nameslist.Count-1);
        nameslist.Add(name.text);
    
        for (int i = 0; i < scorelist.Count; i++)
        {
            for (int j = i; j < scorelist.Count; j++)
            {
                if(scorelist[i]<scorelist[j])
                {
                    int temp = scorelist[i];
                    string temps = nameslist[i];

                    scorelist[i] = scorelist[j];
                    nameslist[i] = nameslist[j];

                    scorelist[j] = temp;
                    nameslist[j] = temps;

                }
            }
        }
        save_data.names = nameslist.ToArray();
        save_data.score = scorelist.ToArray();
        saveLoad.Save();
            Panel.SetActive(false);
        yonet.Menu.SetActive(true);
        
        

    }

    void getData()
    {
        saveLoad.Load();
        nameslist = new List<string>(save_data.names);
        scorelist = new List<int>(save_data.score);
    }
    public void restartGame()
    {
        getData();
        for (int i = 0; i < nameslist.Count; i++)
        { nameslist[i] = " "; scorelist[i] = -1; }
        save_data.names = nameslist.ToArray();
        save_data.score = scorelist.ToArray();
        saveLoad.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);


    }

}
