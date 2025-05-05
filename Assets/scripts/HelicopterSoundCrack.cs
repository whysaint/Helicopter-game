using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class HelicopterSoundCrack : MonoBehaviour
{
    public AudioSource audio;
    public float minPitch = 0.7f;
    public float maxPitch = 1.5f;
    public float helicopterSpeed = 15;
    private Rigidbody _rb;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float speed = _rb.velocity.magnitude;
        float avgSpeed = Mathf.Clamp01(speed / helicopterSpeed);
        audio.pitch = Mathf.Lerp(minPitch, maxPitch, avgSpeed);
    }
}
