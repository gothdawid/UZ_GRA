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
    bool newAtackAloved = true;


    private void Start()
    {
        StartCoroutine(GoToStartPositionInTime());
        StartCoroutine(NextAttack());

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

        // sprawdŸ czy pozycja nie jest zajêta przez inne obiekty
        while (Physics2D.OverlapCircle(spawnPoint, 30f) != null)
        {
            spawnPoint = new Vector3(Random.Range(-750, 750), Random.Range(405, 430), -10);
        }

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
        newAtackAloved = true;
    }

    // IEnumerator EnemyMovement
    // p³ynne poruszanie gracza lewo prawo w przestrzeni 2D
    
    IEnumerator EnemyMove ()
    {
        Vector3 actualPosition = transform.position;
        Vector3 newPosition = new Vector3(Random.Range(-500, 500), Random.Range(300, 300), -10);
        
        // sprawdŸ czy nowa pozycja nie jest zajêta przez inne obiekty
        while (Physics2D.OverlapCircle(newPosition, 30f) != null)
        {
            newPosition = new Vector3(Random.Range(-500, 500), Random.Range(200, 320), -10);
        }
        
        float i = 0;
        while (i <= 1)
        {
            if (gameObject == null) break;
            transform.position = Vector3.Lerp(actualPosition, newPosition, i);
            i += 0.0025f;
            yield return new WaitForSeconds(0.005f);
        }
        newAtackAloved = true;
    }


    // funkcja losuj¹ca nastêpny atak   
    // do wylosowania Kamikadze albo EnemyMove
    // losuje w nieskoñczonoœæ
    // sprawdza czy nastêpny atak jest dozwolony
    // jeœli tak to losuje kolejny

    IEnumerator NextAttack()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            if (newAtackAloved)
            {
                int random = Random.Range(0, 2);
                if (random == 0)
                {
                    StartCoroutine(EnemyMove());
                }
                else
                {
                    StartCoroutine(Kamikadze());
                }
                newAtackAloved = false;
            }
        }
    }
}
