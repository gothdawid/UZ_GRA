using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public void SetVolume (float volume)
    {
        Debug.Log(volume);
    }

    public void SetGraphic(float volume)
    {
        Debug.Log(volume);
    }

    public void SetRes(float volume)
    {
        Debug.Log(volume);
    }

    public void SetFullScren(bool a)
    {
        Debug.Log (a);
    }

    public void ExitSettings()
    {
        Debug.Log("exit");
    }
}
