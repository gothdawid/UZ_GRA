using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponsStatus : MonoBehaviour
{
    public GameObject[] WeaponSpeedLabelsList;
    public GameObject[] WeaponLevelLabelsList;


    void FixedUpdate()
    {
        int i = 1, j = 1;
        foreach (var item in WeaponSpeedLabelsList)
        {
            Image img = item.GetComponent<Image>();
            if (GameManager.weaponSpeedLevel >= i) img.color = new Color(img.color.r, img.color.g, img.color.b, 1f);
            else img.color = new Color(img.color.r, img.color.g, img.color.b, 0.27f);
            i++;
        }

        foreach (var item in WeaponLevelLabelsList)
        {
            Image img = item.GetComponent<Image>();
            if (GameManager.weaponLevel >= j) img.color = new Color(img.color.r, img.color.g, img.color.b, 1f);
            else img.color = new Color(img.color.r, img.color.g, img.color.b, 0.27f);
            j++;
        }
    }
}
