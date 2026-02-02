using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] public ParticleSystem explosionEffect;
    
    void OnCollisionEnter(Collision other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            ParticleSystem effect = Instantiate(explosionEffect, transform.position, Quaternion.identity);

            if (effect != null)
            {
                effect.Play();
            }
            Destroy(effect.gameObject, effect.main.duration);
            
            AudioManader.Instance.PlaySound(Soundtype.BombExplosion);
            Destroy(gameObject);
        }
    }
}