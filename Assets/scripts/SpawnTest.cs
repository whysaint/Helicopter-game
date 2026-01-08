using UnityEngine;

public class SpawnTest : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;

    private void Start()
    {
        Debug.Log("SPAWN TEST START");
        Instantiate(coinPrefab, Vector3.zero, Quaternion.identity);
    }
}
