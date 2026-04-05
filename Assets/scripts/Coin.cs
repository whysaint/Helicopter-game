using UnityEngine;

public class Coin : MonoBehaviour
{
    public static int coinCount = 0;
    
    [SerializeField] private Light _pointLight;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag(GameTags.Player))
        {
            coinCount++;
            gameObject.SetActive(false);
            if (_pointLight != null)
            {
                _pointLight.enabled = false;
            }
            
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.PlaySound(SoundType.Coin);
            }

            if (GameManager.Instance != null)
            {
                GameManager.Instance.OnCoinCollected();
            }
        }
    }
}
