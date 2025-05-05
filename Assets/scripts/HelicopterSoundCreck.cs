using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class HelicopterSoundCreck : MonoBehaviour
{
    public AudioSource audioSound;
    public float minPitch = 0.7f;
    public float maxPitch = 1.6f;
    public float speedHelicopter = 15f;
    private Rigidbody _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        float speed = _rb.velocity.magnitude;
        float speedSeredina = Mathf.Clamp01(speed / speedHelicopter);
        audioSound.pitch = Mathf.Lerp(minPitch, maxPitch, speedSeredina);
    }
}
