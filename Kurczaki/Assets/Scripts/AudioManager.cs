using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.playOnAwake = false;

    }

    public static void PlaySound(AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }
}
