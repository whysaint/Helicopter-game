using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public AudioSource bombSound;
    public ParticleSystem explosionEffect;
    public float timer;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bomb"))
        {
            ParticleSystem effect = Instantiate(explosionEffect, collision.transform.position, Quaternion.identity);
            effect.Play();
            float totalDuration = effect.main.duration + effect.main.startLifetime.constantMax;
            Destroy(effect.gameObject, totalDuration);
            bombSound.Play();
            Destroy(collision.gameObject);
        }
    }
}