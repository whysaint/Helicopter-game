using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class SoundHelicopter : MonoBehaviour
{
    public AudioSource audioHelicopter;
    public float minPitch = 0.8f;
    public float maxPitch = 1.8f;
    public float speedHelicopter = 15f;
    public Animator _animator;
    private Rigidbody _rb;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        SoundPlay();
        AnimationPlay();
    }

    void SoundPlay()
    {
        float speed = _rb.velocity.magnitude;
        float speedProcent = Mathf.Clamp01(speed / speedHelicopter);
        audioHelicopter.pitch = Mathf.Lerp(minPitch, maxPitch, speedProcent);
    }

    void AnimationPlay()
    {
        float speed = _rb.velocity.magnitude;
        float speedProcent = Mathf.Clamp01(speed / speedHelicopter);
        float normolizedSpeedInProcent = Mathf.Lerp(0.50f, 2.0f, speedProcent);
        _animator.SetFloat("SpinSpeed", normolizedSpeedInProcent );
    }
}
