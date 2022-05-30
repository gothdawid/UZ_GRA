using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    //int weapon = 0;
    //int weaponLevel = 0;
    int points = 0;
    public int health = 3;
    public static int actualEnemycount = 0;
    public GameObject enemy, player;
    public Vector3 spawmValues;
    public int enemyCountInWave;
    public float spawnWait, startWait,playerSpawnWait;
    public Text pointsText;
    public Image Heart1, Heart2, Heart3;
    
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
                if (actualEnemycount < 5)
                {
                    Vector3 spawnPoint = new Vector3(Random.Range(-spawmValues.x - 1f, spawmValues.x), spawmValues.y, spawmValues.z);
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
        this.health--;
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
        if (this.health >= 0)
        {
            StartCoroutine(spawnPlayer());
        }
    }

    public void addPoints(int pt)
    {
        points += pt;
        pointsText.text = "Punkty: " + points.ToString();
    }
}
