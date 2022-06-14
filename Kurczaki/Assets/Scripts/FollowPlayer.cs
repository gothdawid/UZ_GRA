using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    Vector3 playerLocation;
    public float speedRotation = 10f;

    // Update is called once per frame
    void Update()
    {
        // Follow the player by tag 
        try
        {
            playerLocation = GameObject.FindGameObjectWithTag("Player").transform.position;
        }
        catch
        {
            playerLocation = new Vector3(0, -380, -10);
        }


        Vector3 vectorToTarget = playerLocation - transform.position;
        float angle = (Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg) - 90;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speedRotation);
    }
}
