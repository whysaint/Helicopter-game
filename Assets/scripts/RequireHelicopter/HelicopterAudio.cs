using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class HelicopterAudio : MonoBehaviour
{
    [Header("Audio Settings")]
    [SerializeField] private AudioSource rotorAudioSource;
    [SerializeField] private float minPitch;
    [SerializeField] private float maxPitch;
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

    private void SetPitchInAudio()
    {
        float magnitude = _helicopterMover.GetMagnitude();
        rotorAudioSource.pitch = Mathf.Lerp(minPitch, maxPitch, magnitude);
    }
}
