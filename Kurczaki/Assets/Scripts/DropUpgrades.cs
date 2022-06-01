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

    void OnTriggerEnter2D(Collider2D collision)
    {
        int chance = Random.Range(0, 99);
        int type = Random.Range(1, 4);
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
        }
    }

    void FixedUpdate()
    {
        
    }
}
