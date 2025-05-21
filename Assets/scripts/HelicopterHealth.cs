using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelicopterHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public Slider healthBar;
    public AudioSource gameOwer;
    public AudioSource damageSound;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.value = currentHealth;
        damageSound.Play();

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        FindObjectOfType<ReplayUI>().ShowReplay();
        Destroy(gameObject);
        gameOwer.Play();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bomb"))
        {
            TakeDamage(30f);
        }
        else if (collision.gameObject.CompareTag("RAMKA"))
        {
            float impactForce = collision.relativeVelocity.magnitude;
            if (impactForce > 5f)
            {
                float damage = impactForce * 2f;
                TakeDamage(damage);
            }
        }
    }
}
