using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropUpgrades : MonoBehaviour
{
    public int HPChance = 5;
    public GameObject HPUpgrade;

    public int WeaponChance = 5;
    public GameObject WeaponUpgrade;

    public int SpeedChance = 5;
    public GameObject SpeedUpgrade;

    public int RocketChance = 5;
    public GameObject RocketCoin;

    public int PointsChance = 5;
    public GameObject PointsCoin;

    void OnTriggerEnter2D(Collider2D collision)
    {
        int chance = Random.Range(0, 99);

        if (chance <= PointsChance)
        {
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(PointsCoin, gameObject.transform.position, spawnRotation);
        }
    }


    void OnDestroy()
    {
        int chance = Random.Range(0, 99);

        int type = Random.Range(1, 5);
        switch (type)
        {
            case 1:
                if(chance <= HPChance)
                {
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(HPUpgrade, gameObject.transform.position, spawnRotation);
                }
                break;
            case 2:
                if (chance <= WeaponChance)
                {
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(WeaponUpgrade, gameObject.transform.position, spawnRotation);
                }
                break;
            case 3:
                if (chance <= SpeedChance)
                {
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(SpeedUpgrade, gameObject.transform.position, spawnRotation);
                }
                break;
            case 4:
                if (chance <= RocketChance)
                {
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(RocketCoin, gameObject.transform.position, spawnRotation);
                }
                break;
        }
    }
}
