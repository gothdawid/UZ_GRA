using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class HighScoresTable : MonoBehaviour
{

    GameObject MainMenu;
    public GameObject TableDialog;
    public Text highScoresText;
    HighScore[] HighScoresTableArray = new HighScore[10];
    void Start()
    {
        MainMenu = GameObject.FindGameObjectWithTag("MainMenu");
        initiateScoresData();
        OpenTable();
    }


    public void initiateScoresData()
    {
        //Create HighScoresTableArray

        //Load array from PlayerPrefs
        for (int i = 0; i < HighScoresTableArray.Length; i++)
        {
            HighScoresTableArray[i] = new HighScore();
            HighScoresTableArray[i].Name = PlayerPrefs.GetString("Name" + i.ToString());
            HighScoresTableArray[i].Score = PlayerPrefs.GetInt("Score" + i.ToString());
        }
        LoadLastScore();
        SortSores();
        SaveScores();
    }

    void LoadLastScore()
    {
        HighScore lastScore = new HighScore();
        lastScore.Name = PlayerPrefs.GetString("Name" + 10.ToString());
        lastScore.Score = PlayerPrefs.GetInt("Score" + 10.ToString());
        if (lastScore.Score > HighScoresTableArray[HighScoresTableArray.Length - 1].Score)
        {
            HighScoresTableArray[HighScoresTableArray.Length - 1] = lastScore;
            print("saved");
        }
        PlayerPrefs.SetString("Name" + 10.ToString(), "");
        PlayerPrefs.SetInt("Score" + 10.ToString(), 0);
        print(lastScore.Name + " " + lastScore.Score);
    }

    void SortSores()
    {
        //Sort array by score
        for (int i = 0; i < HighScoresTableArray.Length; i++)
        {
            for (int j = i + 1; j < HighScoresTableArray.Length; j++)
            {
                if (HighScoresTableArray[i].Score < HighScoresTableArray[j].Score)
                {
                    HighScore temp = HighScoresTableArray[i];
                    HighScoresTableArray[i] = HighScoresTableArray[j];
                    HighScoresTableArray[j] = temp;
                }
            }
        }
    }

    void SaveScores()
    {
        //Save array to PlayerPrefs
        for (int i = 0; i < HighScoresTableArray.Length; i++)
        {
            PlayerPrefs.SetString("Name" + i.ToString(), HighScoresTableArray[i].Name);
            PlayerPrefs.SetInt("Score" + i.ToString(), HighScoresTableArray[i].Score);

            //print
            print(i + " " + HighScoresTableArray[i].Name + " " + HighScoresTableArray[i].Score);
        }
    }



    public void OpenTable()
    {
        MainMenu.SetActive(false);
        TableDialog.SetActive(true);
        ShowTable();
    }

    public void ShowTable()
    {
        if (HighScoresTableArray[0].Score <= 0)
        {
            highScoresText.text = "No scores yet";
        }
        else
        {
            highScoresText.text = "";
            for (int i = 0; i < HighScoresTableArray.Length; i++)
            {
                highScoresText.text += (i + 1).ToString() + ". " + HighScoresTableArray[i].Name + " " + HighScoresTableArray[i].Score + System.Environment.NewLine;
            }
        }
    }


    public void CloseTable()
    {
        Destroy(TableDialog);

        MainMenu.SetActive(true);
    }



}



