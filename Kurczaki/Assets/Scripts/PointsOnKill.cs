using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsOnKill : MonoBehaviour
{
    public int pointsForKill = 5;
    GameObject gameManager;
    GameManager gm;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        gm = (GameManager)gameManager.GetComponent(typeof(GameManager));
    }

    void OnDestroy()
    {
        gm.addPoints(pointsForKill);
    }
}
