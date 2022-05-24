using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour
{
    public float fireDelay = 0.20f;
    public float fire2Delay = 25;
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



    public GameObject bullet;
    public Transform shootPoint;
    float color = 255;
    void Update()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(pos.x, pos.y, -10f);

        if (Input.GetKey(KeyCode.Mouse0) && cooldownTimer <= 0)
        {
            var newBullet = Instantiate(bullet) as GameObject;
            newBullet.transform.position = shootPoint.position;

            cooldownTimer = fireDelay;
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && cooldownTimer2 <= 0)
        {
            Debug.Log("2");
            cooldownTimer2 = fire2Delay;
        }

        color = (float)Math.Ceiling(100f - (cooldownTimer / fireDelay * 200f));

        WeaponImage.color = new Color(255, color, color);
        if(cooldownTimer >= 0) cooldownTimer -= Time.deltaTime;
        if(cooldownTimer2 >= 0) cooldownTimer2 -= Time.deltaTime;
    }
}
