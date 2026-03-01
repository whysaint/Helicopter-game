using UnityEngine;

public class Coin : MonoBehaviour
{
    public static int coinCount = 0;
    
    public Light _pointLight;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            coinCount++;
            Debug.LogWarning(coinCount);
            
            Destroy(gameObject);
            if (_pointLight != null)
            {
                _pointLight.enabled = false;
            }
            
            AudioManader.Instance.PlaySound(Soundtype.Coin);
        }
    }
}
