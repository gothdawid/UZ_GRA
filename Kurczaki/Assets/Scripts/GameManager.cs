using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    //int weapon = 0;
    //int weaponLevel = 0;
    public static int points = 0;
    public static int health = 3;
    public static int actualEnemycount = 0;
    public GameObject enemy, player;
    public Vector3 spawmValues;
    public int enemyCountInWave;
    public float spawnWait, startWait,playerSpawnWait;
    public Text pointsText;
    public Image Heart1, Heart2, Heart3;
    public GameObject gameOverPanel, pausePanel;
    
    public AudioMixer audiomixer;

    void Start()
    {
        StartCoroutine(spawnPlayer());
        StartCoroutine(SpawnWaves());
    }

    float startGain = -80;
    private void FixedUpdate()
    {
        if(startGain < 0)
        {
            audiomixer.SetFloat("mainGain", startGain);
            startGain += 1f;
        }
    }

    IEnumerator spawnPlayer()
    {
        yield return new WaitForSeconds(playerSpawnWait);
        Vector3 spawnPoint = new Vector3(0f,-250f,-10f);
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(player, spawnPoint, spawnRotation);

    }


    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while(true)
        {
            for (int i = 0; i < enemyCountInWave; i++)
            {
                if (actualEnemycount < Mathf.Ceil(GameManager.points / 60) + 1)
                {
                    Vector3 spawnPoint = new Vector3(Random.Range(-spawmValues.x, spawmValues.x), Random.Range(200, 320), spawmValues.z);
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(enemy, spawnPoint, spawnRotation);
                    actualEnemycount++;
                }
                yield return new WaitForSeconds(spawnWait);
                
            }
        }
    }

    public void takeDMG(GameObject obj)
    {
        health--;
        if(health == 2)
        {
            Heart3.enabled = false;
        }
        if (health == 1)
        {
            Heart2.enabled = false;
        }
        if (health == 0)
        {
            Heart1.enabled = false;
        }

        Destroy(obj);
        if (health >= 0)
        {
            StartCoroutine(spawnPlayer());
            PlayerControler.level--;
            PlayerControler.speed--;
        }
        else
        {
            gameOverPanel.SetActive(true);
            
        }
    }

    public void addPoints(int pt)
    {
        points += pt;
        pointsText.text = "Punkty: " + points.ToString();
    }

    public void ReturnToMenu()
    {

        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        paused = false;
        SceneManager.UnloadScene(1);

    }

    public static bool paused = false;
    public void PauseGame()
    {
        if (paused)
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }
        else 
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
        paused = !paused;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameOverPanel.activeSelf) ReturnToMenu();
            if (!gameOverPanel.activeSelf) PauseGame();
        }

    }
}
