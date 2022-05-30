using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
    Vector2 playerLoc = new Vector2(20f,-270f);
    public GameObject bullet;
    public Transform shootPoint;
    public Rigidbody2D rb;


    public float fireDelayMax = 3f, fireDelayMin = 1f;
    float cooldownTimer = 3f;


    private void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        //playerLoc = player.transform.position;
        StartCoroutine(Kamikadze());
    }
    void Update()
    {
        if (cooldownTimer <= 0)
        {
            var newBullet = Instantiate(bullet) as GameObject;
            newBullet.transform.position = shootPoint.position;

            cooldownTimer = Random.Range(fireDelayMin * (200f / GameManager.points), fireDelayMax * (200f / GameManager.points));
        }


        if (cooldownTimer >= 0) cooldownTimer -= Time.deltaTime;

    }


    IEnumerator Kamikadze()
    {
        while(true)
        {
            float timeToAtack = 200 / (GameManager.points + 1f) + 1.5f;
            float timeToAtack2 = 600 / (GameManager.points + 1f) + 3.5f;
            yield return new WaitForSeconds(Random.Range(timeToAtack, timeToAtack2));

            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                Vector3 Startxyz = transform.position;
                Vector3 Endxyz = player.transform.position;
                float i = 0.0f;
                float step = 0.01f;
                while (i < 1.01f)
                {
                    yield return new WaitForSeconds(Random.Range(timeToAtack/300, timeToAtack2/200));
                    transform.position = Vector2.Lerp(Startxyz, Endxyz, i);
                    rb.AddForceAtPosition(new Vector2(50f, 50f), new Vector2(100f, 100f));

                    i += step;
                }
                Vector3 newLoc = new Vector3(Random.Range(-500, 500), Random.Range(200, 300), -10);

                while (i > 0f)
                {

                    yield return new WaitForSeconds(0.02f);
                    transform.position = Vector2.Lerp(newLoc, Endxyz, i);
                    rb.AddForceAtPosition(new Vector2(50f, 50f), new Vector2(100f, 100f));

                    i -= step;
                }
            }
        }



    }
}
