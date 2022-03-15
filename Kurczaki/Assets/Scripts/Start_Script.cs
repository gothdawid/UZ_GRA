using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Start_Script : MonoBehaviour
{

    public void loadGame()
    {
        SceneManager.LoadScene(1);
        SceneManager.UnloadScene(0);

    }

    public void closeGame()
    {
        Application.Quit();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
