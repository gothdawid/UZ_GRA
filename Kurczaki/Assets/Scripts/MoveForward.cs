using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rigibody;
    public float Bulletspeed;

    private void FixedUpdate()
    {
        rigibody.velocity = Vector2.up * Bulletspeed * Time.fixedDeltaTime;
    }
}
