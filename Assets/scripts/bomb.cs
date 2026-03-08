using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private ParticleSystem explosionEffect;
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.root.CompareTag(GameTags.Player))
        {
            if (explosionEffect != null)
            {
                ParticleSystem effect = Instantiate(explosionEffect, transform.position, Quaternion.identity);
                effect.Play();
                Destroy(effect.gameObject, effect.main.duration);
            }
            
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.PlaySound(SoundType.BombExplosion);
            }

            if (GameManager.Instance != null)
            {
                GameManager.Instance.OnLose();
            }

            Destroy(gameObject);
        }
    }
}