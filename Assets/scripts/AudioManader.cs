using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManader : MonoBehaviour
{
    public static AudioManader Instance;
    public AudioSource[] allAudioSource;


    private void Awake()
    {
        Instance = this;
        allAudioSource = FindObjectsOfType<AudioSource>();
        
        float savedVolume = PlayerPrefs.GetFloat("Volume", 1f);
        SetVolume(savedVolume);
    }

    public void SetVolume(float volume)
    {
        foreach (var audio in allAudioSource)
        {
            audio.volume = volume;
        }
        
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();
        PlayerPrefs.Save();
    }
}
