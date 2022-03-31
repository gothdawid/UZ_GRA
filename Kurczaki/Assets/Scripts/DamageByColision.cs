using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageByColision : MonoBehaviour
{
    //public float damage = 1;
    public int health = 1;
    public float invulnTime = 0f;

    int correctLayer;

    private void Start()
    {
        correctLayer = gameObject.layer;
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (invulnTime <= 0)
        {
            health--;
            invulnTime = 2f;

            gameObject.layer = 8;
        }
    }

    void Update()
    {
        invulnTime -= Time.deltaTime;


        if(invulnTime <= 0)
        {
            gameObject.layer = correctLayer;
        }

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

}
