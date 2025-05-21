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
        allAudioSource = FindObjectsOfType<AudioSource>();
    }

    public void SetVolume(float volume)
    {
        foreach (var audio in allAudioSource)
        {
            audio.volume = volume;
        }
    }
}
