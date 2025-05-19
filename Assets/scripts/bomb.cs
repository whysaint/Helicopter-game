using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    public float baseVolume = 1f;
    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void ScaleVolume(float masterVolume)
    {
        source.volume = baseVolume * masterVolume;
    }
}
