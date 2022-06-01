using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject settingsDialog;
    public AudioMixer audiomixer;

    private void Start()
    {
        Application.targetFrameRate = Screen.currentResolution.refreshRate;

    }
    public void newGame()
    {

        SceneManager.UnloadSceneAsync(0);
        SceneManager.LoadScene(1);
    }

    private void Update()
    {

    }

    public void loadGame()
    {
        SceneManager.UnloadSceneAsync(0);
        SceneManager.LoadScene(1);

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
