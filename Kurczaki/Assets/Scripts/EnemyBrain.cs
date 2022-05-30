using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
    Vector2 playerLoc = new Vector2(20f,-270f);
    public GameObject bullet;
    public Transform shootPoint;
    public Rigidbody2D rb;


    public float fireDelayMax = 5f, fireDelayMin = 3f;
    float fireDelay = 5f;
    float cooldownTimer = 5f;


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

            cooldownTimer = Random.Range(fireDelayMin, fireDelayMax);
        }


        if (cooldownTimer >= 0) cooldownTimer -= Time.deltaTime;

    }


    IEnumerator Kamikadze()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(5f,20f));

            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                Vector3 Startxyz = transform.position;
                Vector3 Endxyz = player.transform.position;
                float i = 0.0f;
                float step = 0.01f;
                while (i < 1.01f)
                {
                    yield return new WaitForSeconds(0.02f);
                    transform.position = Vector2.Lerp(Startxyz, Endxyz, i);
                    rb.AddForceAtPosition(new Vector2(50f, 50f), new Vector2(100f, 100f));

                    i += step;
                }

                while (i > 0f)
                {
                    yield return new WaitForSeconds(0.02f);
                    transform.position = Vector2.Lerp(Startxyz, Endxyz, i);
                    rb.AddForceAtPosition(new Vector2(50f, 50f), new Vector2(100f, 100f));

                    i -= step;
                }
            }
        }



    }
}
