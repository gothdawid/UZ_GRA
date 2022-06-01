using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
    public GameObject bullet;
    public Transform[] shootPointsList;
    public Rigidbody2D rb;


    public float fireDelayMin = 1f, fireDelayMax = 3f, kamikadzeDelayMin = 10f, kamikadzeDelayMax = 15f;
    float cooldownTimer = 1.5f;


    private void Start()
    {
        StartCoroutine(GoToStartPositionInTime());
        StartCoroutine(Kamikadze());

    }
    void Update()
    {
        if (cooldownTimer <= 0)
        {
            foreach (Transform shootPoint in shootPointsList)
            {
                var newBullet = Instantiate(bullet) as GameObject;
                newBullet.transform.position = shootPoint.position;
            }
            cooldownTimer = Random.Range(fireDelayMin * (300f / (GameManager.points / 3f + 300f)), fireDelayMax * (300f / (GameManager.points / 3f + 300f)));
        }
        if (cooldownTimer >= 0) cooldownTimer -= Time.deltaTime;
    }


    IEnumerator GoToStartPositionInTime()
    {
        Vector3 startPoint = gameObject.transform.position;
        Vector3 spawnPoint = new Vector3(Random.Range(-750, 750), Random.Range(405, 430), -10);
        float i = 0;
        while (i <= 1)
        {
            if (gameObject == null) break;
            gameObject.transform.position = Vector2.Lerp(spawnPoint, startPoint, i);
            i += 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
    }


    IEnumerator Kamikadze()
    {
        while(true)
        {
            float timeToAtack = kamikadzeDelayMin * GameManager.mnoznikPoziomu;
            float timeToAtack2 = kamikadzeDelayMax * GameManager.mnoznikPoziomu;
            yield return new WaitForSeconds(Random.Range(timeToAtack, timeToAtack2));

            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                Vector3 Startxyz = transform.position;
                Vector3 Endxyz = player.transform.position;
                Endxyz += new Vector3(Random.Range(-100,100), Random.Range(-100, 100), 0);
                float i = 0.0f;
                float step = 0.005f;
                float minSpeed = 0.02f, maxSpeed = 0.01f;
                while (i < 1.01f)
                {
                    yield return new WaitForSeconds(Random.Range(maxSpeed * GameManager.mnoznikPoziomu, minSpeed * GameManager.mnoznikPoziomu));
                    transform.position = Vector2.Lerp(Startxyz, Endxyz, i);

                    i += step;
                }
                Vector3 newLoc = new Vector3(Random.Range(-500, 500), Random.Range(200, 300), -10);

                while (i > 0f)
                {

                    yield return new WaitForSeconds(0.01f);
                    transform.position = Vector2.Lerp(newLoc, Endxyz, i);
                    i -= step;
                }
            }
        }



    }
}
