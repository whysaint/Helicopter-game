using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioManader audioManader;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            audioManader.PlaySound(Soundtype.Coin);
        }
    }
}
