using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


    

public class SettingsMenu : MonoBehaviour
{
    public Dropdown resulutionDropdown;
    public GameObject SettingsDialog;
    public Slider musicSlider, SFXSlider, qualitySlider;
    public Text MusicLabel, FXLabel, qualityLabel;
    public Toggle VsyncToggle, fullscreenToggle;
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

       

        for (int i = 0, j = 0; i < all_resolutions.Length; i++)
        {

            string option = all_resolutions[i].width + "x" + all_resolutions[i].height + " @ " + all_resolutions[i].refreshRate + "Hz";
            if (all_resolutions[i].refreshRate == 30 || all_resolutions[i].refreshRate == 60 || all_resolutions[i].refreshRate == 75 || all_resolutions[i].refreshRate >= 120)
            {
                options.Add(option);
                j++;
            }
            

            if(all_resolutions[i].width == Screen.width &&
                all_resolutions[i].height == Screen.height)
            {
                currentResoulotionIndex = j-1;
            }
            
        }

        resulutionDropdown.AddOptions(options);
        resulutionDropdown.value = currentResoulotionIndex;

        /// SET GAINS ON LABELS
        float volume;
        audioMixer.GetFloat("FXGain", out volume);
        SFXSlider.value = (int)volume;
        FXLabel.text = ((volume + 80f) / 80f * 100).ToString() + "%";

        audioMixer.GetFloat("FXGain", out volume);
        musicSlider.value = (int)volume;
        MusicLabel.text = ((volume + 80f) / 80f * 100).ToString() + "%";

        /// SET VALUE TO GRAPHIC OPTION
        qualitySlider.value = QualitySettings.GetQualityLevel();
        qualityLabel.text = QualitySettings.names[QualitySettings.GetQualityLevel()];

        /// SET TOGGLE VSYNC
        if (QualitySettings.vSyncCount != 0)
        {
            QualitySettings.vSyncCount = 1;
            Application.targetFrameRate = refreshRate;
            VsyncToggle.isOn = true;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = -1;
            VsyncToggle.isOn = false;
        }

        //SET FULLSCREEN TOGGLE

        if(Screen.fullScreen) fullscreenToggle.isOn = true;
        else fullscreenToggle.isOn = false;

    }

    public void SetFXVolume (float volume)
    {
        FXLabel.text = ((volume + 80f) / 80f * 100).ToString() + "%";
        audioMixer.SetFloat("FXGain", volume);

    }

    public void SetMusicVolume(float volume)
    {
        MusicLabel.text = ((volume + 80f) / 80f * 100).ToString() + "%";
        audioMixer.SetFloat("MusicGain", volume);
    }

    public void SetGraphic(float qualityIndex)
    {
        int level = (int)qualityIndex;
        QualitySettings.SetQualityLevel(level);
        qualityLabel.text = QualitySettings.names[level];
    }

    bool vsync = true;

    

    public void SetRes(int index)
    {
        string[] _tmp = resulutionDropdown.options[index].text.Split(' ');
        string[] _tmp2 = _tmp[0].Split('x');

        string _tmp3 = _tmp[2].Replace("Hz", "");

        int height = System.Int32.Parse(_tmp2[1]), width = System.Int32.Parse(_tmp2[0]);
        refreshRate = System.Int32.Parse(_tmp3);

        Screen.SetResolution(width, height, Screen.fullScreen, refreshRate);
        if(vsync) Application.targetFrameRate = refreshRate;

        //Debug.LogError(width.ToString() + "x" + height.ToString() + "@" + refreshRate.ToString());
        //Debug.LogError(Screen.width + "x" + Screen.height + "@" + refreshRate);
    }

    // funkcja pobieraj¹ca dostêpne odœwie¿enia ekranu 
    // i zapisuj¹ca je do tablicy 
    
    


    public void SetVSync(bool a)
    {
        if (a)
        {
            vsync = true;
            Application.targetFrameRate = refreshRate;
        }
        else
        {
            vsync = false;
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
