using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    int weapon = 0;
    int weaponLevel = 0;
    int points = 0;
    int lives = 3;

    public AudioMixer audiomixer;

    void Start()
    {

    }

    float startGain = -80;
    private void FixedUpdate()
    {
        if(startGain < 0)
        {
            audiomixer.SetFloat("mainGain", startGain);
            startGain += 1f;
        }
    }

    void Update()
    {
        
    }
}
