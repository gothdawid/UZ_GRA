using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Slider resulutionSlider;

    public Text restLabel;

    Resolution[] resolutions;

    List<string> options = new List<string>();

    void Start()
    {
        resolutions = Screen.resolutions;


        int currentResoulotionIndex = 0;

        int i = 0;
        for (i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResoulotionIndex = i;
            }

        }

        resulutionSlider.value = currentResoulotionIndex;
        restLabel.text = options[currentResoulotionIndex];
        resulutionSlider.maxValue = i;
    }

    public void SetVolume (float volume)
    {
        Debug.Log(volume);
    }

    public void SetGraphic(float qualityIndex)
    {
        int level = (int)qualityIndex;

        QualitySettings.SetQualityLevel(level);
    }

    public void SetRes(float index)
    {

        Resolution resolution = resolutions[(int)index];
        Screen.SetResolution(resolution.width,resolution.height, Screen.fullScreen);
        restLabel.text = options[(int)index];

    }

    public void SetFullScren(bool a)
    {
        Screen.fullScreen = a;
    }

    public void ExitSettings()
    {
        Debug.Log("exit");
    }
}
