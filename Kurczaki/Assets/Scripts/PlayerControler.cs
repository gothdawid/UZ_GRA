using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{

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
        transform.position = new Vector2(pos.x, pos.y);


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            var newBullet = Instantiate(bullet) as GameObject;
            newBullet.transform.position = shootPoint.position;
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Debug.Log("1");
        }


    }
}
