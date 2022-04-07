using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject settingsDialog;

    public void newGame()
    {
        SceneManager.LoadScene(1);
        SceneManager.UnloadScene(0);
    }


    public void loadGame()
    {
        SceneManager.LoadScene(1);
        SceneManager.UnloadScene(0);

    }

    public void closeGame()
    {
        Application.Quit();
    }

    public void openSettings()
    {
        Instantiate(settingsDialog);
    }
}
