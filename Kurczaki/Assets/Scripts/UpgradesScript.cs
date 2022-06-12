using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesScript : MonoBehaviour
{
    GameManager gm;
    GameObject gameManager;
    public AudioClip upgradeSound;

    private void Start()
    {

        gameManager = GameObject.Find("GameManager");
        gm = (GameManager)gameManager.GetComponent(typeof(GameManager));
    }
    


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            switch (gameObject.tag)
            {
                case "Speed":
                    {
                        if (GameManager.weaponSpeedLevel < GameManager.maxWeaponSpeedLevel) GameManager.weaponSpeedLevel++;
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
                case "Points":
                    {
                        gm.addPoints(25);
                        break;
                    }
                case "Rocket":
                    {
                        //if (GameManager.health < GameManager.maxHealth) gm.addHealth();
                        break;
                    }
            }
            Debug.Log(upgradeSound.length);
            AudioManager.PlaySound(upgradeSound);
            Destroy(gameObject);
        }
    }
}
