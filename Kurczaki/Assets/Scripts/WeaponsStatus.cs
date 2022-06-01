using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsStatus : MonoBehaviour
{
    public GameObject[] WeaponSpeedLabelsList;
    public GameObject[] WeaponLevelLabelsList;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in WeaponSpeedLabelsList)
        {
            item.SetActive(false);
        }

        foreach (var item in WeaponLevelLabelsList)
        {
            item.SetActive(false);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int i = 1, j = 1;
        foreach (var item in WeaponSpeedLabelsList)
        {
            if (GameManager.weaponSpeedLevel >= i) item.SetActive(true);
            else item.SetActive(false);
            i++;
        }

        foreach (var item in WeaponLevelLabelsList)
        {
            if(GameManager.weaponLevel >= j) item.SetActive(true);
            else item.SetActive(false);
            j++;
        }
    }
}
