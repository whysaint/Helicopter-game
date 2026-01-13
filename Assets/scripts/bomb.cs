using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] public ParticleSystem explosionEffect;
    [SerializeField] public float bounceForce;
    
    public float timer;


    void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            ParticleSystem effect = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            
            effect.Play();
            
            float totalDuration = effect.main.duration + effect.main.startLifetime.constantMax;
            
            Destroy(effect.gameObject, totalDuration);
            
            AudioManader.Instance.PlaySound(Soundtype.BombExplosion);
            Destroy(gameObject);
        }
    }
}