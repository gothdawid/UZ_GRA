using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DamageByColision : MonoBehaviour
{
    //public float damage = 1;
    public int health = 1;
    GameObject gameManager;
    public GameObject PlayerExplosion, EnemyExplosion;
    GameManager gm;

    int correctLayer;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        gm = (GameManager)gameManager.GetComponent(typeof(GameManager));

    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            switch(collision.gameObject.tag)
            {
                case "Speed":
                    {
                        if(GameManager.weaponSpeedLevel < GameManager.maxWeaponSpeedLevel) GameManager.weaponSpeedLevel++;
                        break;
                    }
                case "Level":
                    {
                        if (GameManager.weaponLevel < GameManager.maxWeaponLevel) GameManager.weaponLevel++;
                        break;
                    }
                case "HP":
                    {
                        if (GameManager.health < GameManager.maxHealth) gm.addHealth();
                        break;
                    }
            }
            Destroy(collision.gameObject);
        }
        else if(gameObject.layer == 6)
        {
            if (PlayerExplosion != null) Instantiate(PlayerExplosion, transform.position, transform.rotation);
            gm.takeDMG(gameObject);
        }
        else
        {
            health--;
        }
    }

    void Update()
    {
        if(health <= 0)
        {
            if(EnemyExplosion != null) Instantiate(EnemyExplosion, transform.position, transform.rotation);

            Destroy(gameObject);
        }
    }


}
