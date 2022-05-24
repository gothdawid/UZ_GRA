using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsOnKill : MonoBehaviour
{
    public int pointsForKill = 5;
    GameManager gm;

    private void Start()
    {

    }

    void OnDestroy()
    {

        gm = (GameManager)GameObject.Find("GameManager").GetComponent(typeof(GameManager));

        gm.addPoints(pointsForKill);
    }
}
