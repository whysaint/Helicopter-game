using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource sfxSource;      
    [SerializeField] private AudioSource musicSource;   

    [Header("SFX Clips")]
    [SerializeField] private AudioClip coinSound;
    [SerializeField] private AudioClip bombSound;
    [SerializeField] private AudioClip buttonClick;

    [Header("Music Clips")]
    [SerializeField] private AudioClip mainMenuMusic;
    [SerializeField] private AudioClip inGameMusic;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            Instance = null;
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        switch (scene.name)
        {
            case "MainMenu":
                PlayMusic(mainMenuMusic, true);
                break;

            case "1":
                PlayMusic(inGameMusic, true);
                break;
        }
    }

    public void PlayMusic(AudioClip clip, bool loop = true, float volume = 1f)
    {
        if (musicSource == null || clip == null) return;

        musicSource.clip = clip;
        musicSource.loop = loop;
        musicSource.volume = volume;
        musicSource.Play();
    }

    public void PlaySound(SoundType type)
    {
        if (sfxSource == null) return;

        switch (type)
        {
            case SoundType.Coin:
                if (coinSound != null)
                    sfxSource.PlayOneShot(coinSound);
                break;

            case SoundType.BombExplosion:
                if (bombSound != null)
                    sfxSource.PlayOneShot(bombSound);
                break;

            case SoundType.ButtonClick:
                if (buttonClick != null)
                    sfxSource.PlayOneShot(buttonClick);
                break;

            case SoundType.Win:
            case SoundType.Lose:
                break;
        }
    }
    
    public void PlayButtonClick()
    {
        PlaySound(SoundType.ButtonClick);
    }
}