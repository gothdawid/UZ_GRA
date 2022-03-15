using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    // Start is called before the first frame update


    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined; 
        Cursor.visible = false;
    }




    // Update is called once per frame
    void Update()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(pos.x, pos.y);



        var game_k_controler = Keyboard.current;
        var game_m_controler = Mouse.current;

        if (game_k_controler == null) return;
        if (game_k_controler.leftArrowKey.wasPressedThisFrame)
        {
            Debug.Log("Left");
        }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Tfiu!");
        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Ka Bum!");
        }
    }
}
