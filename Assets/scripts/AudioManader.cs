using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManader : MonoBehaviour
{
    public static AudioManader Instance;
    public AudioSource[] allAudioSource;
    private bomb[] bombVolumes;

    private void Awake()
    {
        allAudioSource = FindObjectsOfType<AudioSource>();
        bombVolumes = FindObjectsOfType<bomb>();
    }

    public void SetVolume(float volume)
    {
        foreach (var audio in allAudioSource)
        {
            audio.volume = volume;
        }

        foreach (var bomb in bombVolumes)
        {
            bomb.ScaleVolume(volume);
        }
    }
}
