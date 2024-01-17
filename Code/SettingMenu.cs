using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Resolution[] resolution;
    public TMPro.TMP_Dropdown resolutionDropdown;
    int currentResolutionIndex = 0;


    private void Start()
    {
        resolution = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        for (int i = 0; i < resolution.Length ;i++)
        {
            string option = resolution[i].width + "X" + resolution[i].height;
            options.Add(option);
            if (resolution[i].width == Screen.currentResolution.width && resolution[i].height == Screen.currentResolution.height) 
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionindex)
    {
        Resolution resolutions = resolution[resolutionindex];
        Screen.SetResolution(resolutions.width, resolutions.height, Screen.fullScreen);
    }
    public void SettingVolume(float volume)
    {
        audioMixer.SetFloat("Volume",volume );
    }
    public void SetFullScreen(bool Isfullscreen)
    {
        Screen.fullScreen = Isfullscreen;
    }
}
