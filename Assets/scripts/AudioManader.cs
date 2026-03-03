using System;
using UnityEngine;
using UnityEngine.Serialization;

public class AudioManader : MonoBehaviour
{
    public static AudioManader Instance;

    public AudioSource audioSource;
    public AudioSource backgroundAudioSource;
    
    public AudioClip coinSound;
    public AudioClip bombSound;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if (backgroundAudioSource != null)
        {
            backgroundAudioSource.Play();
        }
    }

    public void PlaySound(Soundtype type)
    {
        
        Debug.Log("PLAY SOUND: " + type);

        
        switch (type)
        {
            case Soundtype.Coin:
                audioSource.PlayOneShot(coinSound);
                break;
            
            case Soundtype.BombExplosion:
                audioSource.PlayOneShot(bombSound);
                break;
            
            case Soundtype.Win:
                Debug.LogWarning("Sound not assigned");
                break;
            
            case Soundtype.Lose:
                Debug.LogWarning("Sound not assigned");
                break;
        }
    }
}
