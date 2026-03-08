using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource backgroundAudioSource;
    [SerializeField] private AudioClip coinSound;
    [SerializeField] private AudioClip bombSound;
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void Start()
    {
        if (backgroundAudioSource != null)
        {
            backgroundAudioSource.Play();
        }
    }

    public void PlaySound(SoundType type)
    {
        if (audioSource == null) return;
        
        switch (type)
        {
            case SoundType.Coin:
                if (coinSound != null)
                    audioSource.PlayOneShot(coinSound);
                break;
            
            case SoundType.BombExplosion:
                if (bombSound != null)
                    audioSource.PlayOneShot(bombSound);
                break;
            
            case SoundType.Win:
            case SoundType.Lose:
                break;
        }
    }
}
