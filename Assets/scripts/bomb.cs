using UnityEngine;

public class Bomb : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.root.CompareTag(GameTags.Player))
        {
            if (ExplosionPool.Instance != null)
            {
                ExplosionPool.Instance.PlayExplosion(transform.position);
            }

            if (AudioManager.Instance != null)
                AudioManager.Instance.PlaySound(SoundType.BombExplosion);

            if (GameManager.Instance != null)
                GameManager.Instance.OnLose();

            gameObject.SetActive(false);
        }
    }
}