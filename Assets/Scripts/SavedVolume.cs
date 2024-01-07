using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedVolume : MonoBehaviour
{
    public List<AudioSource> sfxAudioSources = new List<AudioSource>();
    public List<AudioSource> musicAudioSources = new List<AudioSource>();
    
    void Start()
    {
        float savedMusicVolume = PlayerPrefs.GetFloat("musicVolume", 1f);
        foreach (AudioSource musicSource in musicAudioSources)
        {
            musicSource.volume = savedMusicVolume;
        }
        float savedSFXVolume = PlayerPrefs.GetFloat("sfxVolume", 1f);
        foreach (AudioSource sfxSource in sfxAudioSources)
        {
            sfxSource.volume = savedSFXVolume;
        }
    }
}
