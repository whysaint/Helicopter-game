using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            Destroy(gameObject);
            AudioManader.Instance.PlaySound(Soundtype.Coin);
        }
    }
}
