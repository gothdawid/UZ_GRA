using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static int points = 0;
    public static int health = 4, weaponLevel = 1, weaponSpeedLevel = 1;
    public static int actualEnemycount = 0;
    public GameObject player;
    public GameObject[] enemies;
    public Vector3 spawmValues;
    public float spawnWait, startWait,playerSpawnWait;
    public Text pointsText;
    public Image Heart1, Heart2, Heart3;
    public GameObject gameOverPanel, pausePanel;

    public static bool paused = false;
    private bool hasCollide = false;

    public static int maxHealth = 5, maxWeaponLevel = 7, maxWeaponSpeedLevel = 7;
    
    public AudioMixer audiomixer;

    public static float mnoznikPoziomu = 1;

    void Start()
    {
        weaponLevel = 1; weaponSpeedLevel = 1;
        points = 0; health = 3; actualEnemycount = 0;
        StartCoroutine(spawnPlayer());
        StartCoroutine(SpawnWaves());
    }

    float startGain = -80;
    void FixedUpdate()
    {
        mnoznikPoziomu = (1000f / (points / 6f + 1000f));

        if (startGain < 0)
        {
            audiomixer.SetFloat("mainGain", startGain);
            startGain += 1f;
        }
    }

    IEnumerator spawnPlayer()
    {

        yield return new WaitForSeconds(playerSpawnWait);
        hasCollide = false;
        Vector3 spawnPoint = new Vector3(0f,-250f,-10f);
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(player, spawnPoint, spawnRotation);
    }


    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        GameObject enemy;
        while (true)
        {
            int chance = Random.Range(0, 99);

            if (chance < 12 && points > 1100) enemy = enemies[3];
            else if (chance < 30 && points > 600) enemy = enemies[2];
            else if(chance < 50 && points > 300) enemy = enemies[1];
            else enemy = enemies[0];



            if (actualEnemycount < Mathf.Ceil(GameManager.points / 300) + 3)
            {
                Vector3 startPoint = new Vector3(Random.Range(-spawmValues.x, spawmValues.x), Random.Range(200, 320), spawmValues.z);
                // sprawdŸ czy pozycja startowa nie jest zajêta przez inny obiekt
                while (Physics2D.OverlapCircle(startPoint, 30f) != null)
                {
                    startPoint = new Vector3(Random.Range(-spawmValues.x, spawmValues.x), Random.Range(200, 320), spawmValues.z);
                }
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(enemy, startPoint, spawnRotation);

                actualEnemycount++;
            }
            yield return new WaitForSeconds(spawnWait); 
        }
    }

    
    public void takeDMG(GameObject obj)
    {
        if(!hasCollide)
        {
            health--;
            hasCollide = true;
            Destroy(obj);
        }

        if(health > 0)
        {
            StartCoroutine(spawnPlayer());
            if (weaponLevel > 1) weaponLevel--;
            if (weaponSpeedLevel > 1) weaponSpeedLevel--;
        }
        else
        {
            Destroy(obj);
            ShowGameOverPanel();
        }
        Debug.Log(health);

        updateHealthBar();
    }

    public void addHealth()
    {
        health++;
        updateHealthBar();
    }

    public void updateHealthBar()
    {
        Debug.Log(health);
        if(health >= 3) Heart3.enabled = true;
        if (health >= 2) Heart2.enabled = true;
        if (health >= 1) Heart1.enabled = true;

        if(health < 3) Heart3.enabled = false;
        if(health < 2) Heart2.enabled = false;
        if(health < 1) Heart1.enabled = false;

    }

    public void addPoints(int pt)
    {
        points += pt;
        pointsText.text = "Punkty: " + points.ToString();
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1;
        paused = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.UnloadSceneAsync(1);
        SceneManager.LoadScene(0);
    }

    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0.6f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void PauseGame()
    {
        if (paused)
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;
        }
        else 
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0.02f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
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
