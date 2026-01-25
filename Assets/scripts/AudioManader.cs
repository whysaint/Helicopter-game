using Unity.VisualScripting;
using UnityEngine;

public class AudioManader : MonoBehaviour
{
    public static AudioManader Instance;
    public AudioSource[] allAudioSource;

    public AudioSource audioSource;
    
    public AudioClip coinSound;
    public AudioClip bombSound;
    public AudioSource helicopterRotor; 
    
    private void Awake()
    {
        Instance = this;

        audioSource = GetComponent<AudioSource>();
        allAudioSource = FindObjectsOfType<AudioSource>();
        
        float savedVolume = PlayerPrefs.GetFloat("Volume", 1f);
        SetVolume(savedVolume);
        
        Debug.Log("Saved volume: " + savedVolume);
    }

    public void SetVolume(float volume)
    {
        foreach (var audio in allAudioSource)
        {
            audio.volume = volume;
        }
        
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();
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
    
    public void SetHelicopterRotorPitch(float normalizedSpeed)
    {
        helicopterRotor.pitch = Mathf.Lerp(0.8f, 1.8f, normalizedSpeed);

        Debug.Log("SetHelicopterRotorPitch");
 
        if (!helicopterRotor.isPlaying) helicopterRotor.Play();
    }
}
