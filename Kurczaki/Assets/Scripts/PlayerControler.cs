using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    public float fireDelay = 0.20f;
    public float fire2Delay = 25;
    float cooldownTimer = 0;
    float cooldownTimer2 = 0;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined; 
        Cursor.visible = false;
    }



    public GameObject bullet;
    public Transform shootPoint;

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
            Debug.Log("1");
            cooldownTimer2 = fire2Delay;
        }

        cooldownTimer -= Time.deltaTime;
        cooldownTimer2 -= Time.deltaTime;
    }
}
