using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class HelicopterAudio : MonoBehaviour
{
    [Header("Audio Settings")] 
    [SerializeField] public AudioSource rotorAudioSource;
    [SerializeField] public float minPitch;
    [SerializeField] public float maxPitch;
    [SerializeField] private float startOffset = 0.1f;

    private HelicopterMover _helicopterMover;

    private void Start()
    {
        _helicopterMover = GetComponent<HelicopterMover>();

        if (rotorAudioSource != null)
        {
            rotorAudioSource = GetComponent<AudioSource>();
            rotorAudioSource.loop = true;
            rotorAudioSource.playOnAwake = false;
        }
    }
    
    private void OnEnable()
    {
        if (rotorAudioSource != null && !rotorAudioSource.isPlaying)
        {
            rotorAudioSource.Play();
        }
    }
    
    private void OnDisable()
    {
        if (rotorAudioSource != null)
        {
            rotorAudioSource.Stop();
        }
    }

    private void Update()
    {
        SetPitchInAudio();
    }

    void SetPitchInAudio()
    {
        float magnitude = _helicopterMover.GetMagnitude();

        /*if (rotorAudioSource != )
        {
            
        }
        
        rotorAudioSource.time = startOffset;*/
        
        rotorAudioSource.pitch = Mathf.Lerp(minPitch, maxPitch, magnitude);
    }
}
