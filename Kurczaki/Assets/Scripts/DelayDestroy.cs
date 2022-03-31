using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayDestroy : MonoBehaviour
{
    public float delaySuicide = 2f;
    
    
    void Update()
    {
        delaySuicide -= Time.deltaTime;
        if (delaySuicide <= 0)
        {
            Destroy(gameObject);
        }


    }
}
