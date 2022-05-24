using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvulnOnSpawn : MonoBehaviour
{
    public float invulnTime = 2f;
    float invulnTimer = 0;
    int correctLayer;

    // Start is called before the first frame update
    void Start()
    {
        invulnTimer = invulnTime;
        correctLayer = gameObject.layer;
        gameObject.layer = 8;

    }

    // Update is called once per frame
    void Update()
    {
        if (invulnTimer > 0)
        {
            invulnTimer -= Time.deltaTime;

            if (invulnTimer <= 0)
            {
                gameObject.layer = correctLayer;
            }
        }
    }
}
