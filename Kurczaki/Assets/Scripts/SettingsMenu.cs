using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


    

public class SettingsMenu : MonoBehaviour
{
    public Dropdown resulutionDropdown;
    public GameObject SettingsDialog;

    public Text MusicLabel, FXLabel, qualityLabel;
    Resolution[] all_resolutions;
    int refreshRate = -1;

    public AudioMixer audioMixer;

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
            if (all_resolutions[i].refreshRate == 30 || all_resolutions[i].refreshRate == 60 || all_resolutions[i].refreshRate >= 120)
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
        audioMixer.SetFloat("FXGain", volume);

    }
    public void SetMusicVolume(float volume)
    {
        MusicLabel.text = (volume).ToString()+"%";
        audioMixer.SetFloat("MusicGain", volume);
    }

    public void SetGraphic(float qualityIndex)
    {
        int level = (int)qualityIndex;
        QualitySettings.SetQualityLevel(level);
        qualityLabel.text = QualitySettings.names[level];
    }

    public void SetRes(int index)
    {
        string[] _tmp = resulutionDropdown.options[index].text.Split(' ');
        string[] _tmp2 = _tmp[0].Split('x');

        string _tmp3 = _tmp[2].Replace("Hz", "");

        int height = System.Int32.Parse(_tmp2[1]), width = System.Int32.Parse(_tmp2[0]);
        refreshRate = System.Int32.Parse(_tmp3);

        Screen.SetResolution(width, height, Screen.fullScreen, refreshRate);


        Application.targetFrameRate = refreshRate;

        //Debug.LogError(width.ToString() + "x" + height.ToString() + "@" + refreshRate.ToString());
        //Debug.LogError(Screen.currentResolution.width + "x" + Screen.currentResolution.height + "@" + Screen.currentResolution.refreshRate);
    }

    public void SetVSync(bool a)
    {
        if (a)
        {
            QualitySettings.vSyncCount = 1;
            Application.targetFrameRate = refreshRate;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = -1;
        }
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
