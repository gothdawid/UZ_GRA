using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour
{
    public float fireDelay = 0.5f;
    public float fire2Delay = 25;
    public GameObject bullet;
    public Transform[] shootPointsList;
    float cooldownTimer = 0;
    float cooldownTimer2 = 0;
    GameObject gObj;
    Image WeaponImage;


    void Start()
    {
        gObj = GameObject.Find("WeaponImage");
        WeaponImage = (Image)gObj.GetComponent(typeof(Image));


        Cursor.lockState = CursorLockMode.Confined; 
        Cursor.visible = false;
    }

    float color = 255;
    void Update()
    {
        if (GameManager.paused) return;

        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(pos.x, pos.y, -10f);

        if (Input.GetKey(KeyCode.Mouse0) && cooldownTimer <= 0)
        {
            switch (GameManager.weaponLevel)
            {
                case 1: {
                        var newBullet = Instantiate(bullet) as GameObject;
                        newBullet.transform.position = shootPointsList[0].position;
                        break;
                    }
                case 2:
                    {
                        var newBullet = Instantiate(bullet) as GameObject;
                        var newBullet2 = Instantiate(bullet) as GameObject;
                        newBullet.transform.position = shootPointsList[1].position;
                        newBullet2.transform.position = shootPointsList[2].position;
                        break;
                    }
                case 3:
                    {
                        var newBullet = Instantiate(bullet) as GameObject;
                        var newBullet2 = Instantiate(bullet) as GameObject;
                        var newBullet3 = Instantiate(bullet) as GameObject;
                        newBullet.transform.position = shootPointsList[0].position;
                        newBullet2.transform.position = shootPointsList[2].position;
                        newBullet3.transform.position = shootPointsList[1].position;
                        break;
                    }

                case 4:
                    {
                        var newBullet = Instantiate(bullet) as GameObject;
                        var newBullet2 = Instantiate(bullet) as GameObject;
                        var newBullet3 = Instantiate(bullet) as GameObject;
                        newBullet.transform.position = shootPointsList[0].position;
                        newBullet2.transform.position = shootPointsList[2].position;
                        newBullet2.transform.rotation = shootPointsList[2].rotation;
                        newBullet3.transform.position = shootPointsList[1].position;
                        newBullet3.transform.rotation = shootPointsList[1].rotation;
                        break;
                    }
                case 5:
                    {
                        var newBullet = Instantiate(bullet) as GameObject;
                        var newBullet2 = Instantiate(bullet) as GameObject;
                        var newBullet3 = Instantiate(bullet) as GameObject;
                        var newBullet4 = Instantiate(bullet) as GameObject;
                        newBullet.transform.position = shootPointsList[1].position;
                        newBullet2.transform.position = shootPointsList[2].position;
                        newBullet3.transform.position = shootPointsList[3].position;
                        newBullet3.transform.rotation = shootPointsList[3].rotation;
                        newBullet4.transform.position = shootPointsList[4].position;
                        newBullet4.transform.rotation = shootPointsList[4].rotation;
                        break;
                    }
                case 6:
                    {
                        var newBullet = Instantiate(bullet) as GameObject;
                        var newBullet2 = Instantiate(bullet) as GameObject;
                        var newBullet3 = Instantiate(bullet) as GameObject;
                        var newBullet4 = Instantiate(bullet) as GameObject;
                        var newBullet5 = Instantiate(bullet) as GameObject;
                        newBullet.transform.position = shootPointsList[1].position;

                        newBullet2.transform.position = shootPointsList[2].position;

                        newBullet3.transform.position = shootPointsList[3].position;
                        newBullet3.transform.rotation = shootPointsList[3].rotation;

                        newBullet4.transform.position = shootPointsList[4].position;
                        newBullet4.transform.rotation = shootPointsList[4].rotation;

                        newBullet5.transform.position = shootPointsList[0].position;
                        break;
                    }
                default:
                    {
                        var newBullet = Instantiate(bullet) as GameObject;
                        var newBullet2 = Instantiate(bullet) as GameObject;
                        var newBullet3 = Instantiate(bullet) as GameObject;
                        var newBullet4 = Instantiate(bullet) as GameObject;
                        var newBullet5 = Instantiate(bullet) as GameObject;
                        newBullet.transform.position = shootPointsList[1].position;
                        newBullet.transform.rotation = Quaternion.Euler(0, 0, shootPointsList[1].rotation.z + 2);

                        newBullet2.transform.position = shootPointsList[2].position;
                        newBullet2.transform.rotation = Quaternion.Euler(0, 0, shootPointsList[1].rotation.z - 2);

                        newBullet3.transform.position = shootPointsList[3].position;
                        newBullet3.transform.rotation = shootPointsList[3].rotation;

                        newBullet4.transform.position = shootPointsList[4].position;
                        newBullet4.transform.rotation = shootPointsList[4].rotation;

                        newBullet5.transform.position = shootPointsList[0].position;
                        break;
                    }
            }
            switch (GameManager.weaponSpeedLevel)
            {
                case 1:
                    {
                        cooldownTimer = fireDelay;
                        break;
                    }
                case 2:
                    {
                        cooldownTimer = fireDelay - fireDelay / 12f * 1;
                        break;
                    }
                case 3:
                    {
                        cooldownTimer = fireDelay - fireDelay / 12f * 2f;
                        break;
                    }
                case 4:
                    {
                        cooldownTimer = fireDelay - fireDelay / 12f * 3f;
                        break;
                    }
                case 5:
                    {
                        cooldownTimer = fireDelay - fireDelay / 12f * 4f;
                        break;
                    }
                case 6:
                    {
                        cooldownTimer = fireDelay - fireDelay / 12f * 5f;
                        break;
                    }
                case 7:
                    {
                        cooldownTimer = fireDelay - fireDelay / 12f * 6f;
                        break;
                    }
                default:
                    {
                        cooldownTimer = fireDelay - fireDelay / 10f * 2.5f;
                        break;
                    }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && cooldownTimer2 <= 0)
        {
            cooldownTimer2 = fire2Delay;
        }

        color = (float)Math.Ceiling(100f - (cooldownTimer / fireDelay * 200f));

        WeaponImage.color = new Color(255, color, color);
        if(cooldownTimer >= 0) cooldownTimer -= Time.deltaTime;
        if(cooldownTimer2 >= 0) cooldownTimer2 -= Time.deltaTime;
    }
}
