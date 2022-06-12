using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public Rigidbody2D rigibody;
    public float Bulletspeed;

    private void FixedUpdate()
    {
        Vector2 velocity = Vector2.up * Bulletspeed * Time.fixedDeltaTime;

        Quaternion rot = gameObject.transform.rotation;
        rigibody.velocity = rot * velocity;
        //ustaw wzglêdem obrotu
        
    }
}
