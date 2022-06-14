using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroySpawn : MonoBehaviour
{
    public GameObject Explosion;
    public bool killenemy = true;
    public int distanceToKillPlayer = 40;
    bool isDestroyed = false;
    
    GameManager gm;

    private void Start()
    {
        gm = (GameManager)GameObject.Find("GameManager").GetComponent(typeof(GameManager));
    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            if (!killenemy)
            {
                isDestroyed = true;
                Destroy(gameObject);
            }
        }
    }


    void OnDestroy()
    {
        if (Explosion != null) Instantiate(Explosion, transform.position, transform.rotation);

        if (killenemy)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                enemy.GetComponent<DamageByColision>().health = 0;
            }
        }
        else
        {
            if (!isDestroyed)
            {
                GameObject player = GameObject.FindGameObjectWithTag("Player");

                if (Vector3.Distance(transform.position, player.transform.position) < distanceToKillPlayer)
                {
                    gm.takeDMG(player);
                }
            }
        }
    }
}
