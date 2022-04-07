using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


    

public class SettingsMenu : MonoBehaviour
{
    public Dropdown resulutionDropdown;
    public GameObject SettingsDialog;

    public Text MusicLabel, FXLabel, QualityLabel;
    Resolution[] all_resolutions;
    



    List<string> options = new List<string>();
    GameObject MainMenu;
    void Start()
    {
        MainMenu = GameObject.FindGameObjectWithTag("MainMenu");
        MainMenu.SetActive(false);

        all_resolutions = Screen.resolutions;

        int currentResoulotionIndex = 0;
        resulutionDropdown.ClearOptions();

        int i = 0;
        for (i = 0; i < all_resolutions.Length; i++)
        {

            string option = all_resolutions[i].width + "x" + all_resolutions[i].height + " @ " + all_resolutions[i].refreshRate + "Hz";

            if (!options.Contains(option))
            {
                options.Add(option);
            }

            if(all_resolutions[i].width == Screen.currentResolution.width &&
                all_resolutions[i].height == Screen.currentResolution.height)
            {
                currentResoulotionIndex = i;
            }
  
        }

        resulutionDropdown.AddOptions(options);
        resulutionDropdown.value = currentResoulotionIndex;
    }

    public void SetFXVolume (float volume)
    {
        FXLabel.text = (volume ).ToString()+"%";
    }
    public void SetMusicVolume(float volume)
    {
        MusicLabel.text = (volume).ToString()+"%";
    }

    public void SetGraphic(float qualityIndex)
    {
        int level = (int)qualityIndex;
        QualitySettings.SetQualityLevel(level);
        QualityLabel.text = QualitySettings.names[level];

    }

    public void SetRes(int index)
    {

        Resolution resolution = all_resolutions[(int)index];
        Screen.SetResolution(resolution.width,resolution.height, Screen.fullScreen);
        //resoulutionLabel.text = options[(int)index];

    }

    public void SetFullScren(bool a)
    {
        Screen.fullScreen = a;
    }

    public void ExitSettings()
    {
        Destroy(SettingsDialog);

        MainMenu.SetActive(true);
    }
}
