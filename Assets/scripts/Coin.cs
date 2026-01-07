using UnityEngine;

public class Coin : MonoBehaviour
{
    private AudioManader _audioManader;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            _audioManader.PlaySound(Soundtype.Coin);
        }
    }
}
