using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    public Slider volumeSlider;
    public Slider sfxSlider;
    public AudioSource audioSource;
    public GameObject settingsPanel;
    public GameObject settingsBTN;
    public List<AudioSource> sfxAudioSources = new List<AudioSource>();
    public GameObject PauseMenu;


    void Start()
    {
        if (audioSource == null)
        {
            Debug.LogError("AudioSource not assigned to VolumeControl script!");
            return;
        }
        volumeSlider.value = audioSource.volume;
        sfxSlider.value = audioSource.volume;
        settingsPanel.SetActive(false);
        settingsBTN.SetActive(true);
    }
    public void OnVolumeChanged()
    {
        audioSource.volume = volumeSlider.value;
    }

    public void ShowSettingsPage()
    {
        settingsPanel.SetActive(true);
        settingsBTN.SetActive(false);
        PauseMenu.SetActive(false);
    }
    public void CloseSettingsPage()
    {
        settingsPanel.SetActive(false);
        settingsBTN.SetActive(true);
        PauseMenu.SetActive(true);
    }

    public void OnSFXVolumeChanged()
    {
        foreach (AudioSource sfxSource in sfxAudioSources)
        {
            if (sfxSource != null)
            {
                sfxSource.volume = sfxSlider.value;
            }
        }
    }


}
