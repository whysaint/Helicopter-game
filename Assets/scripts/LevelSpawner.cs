using UnityEngine;
using Random = UnityEngine.Random;

public class LevelSpawner : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private Vector3 minSpawnBounds;
    [SerializeField] private Vector3 maxSpawnBounds;
    [SerializeField] private int coinCount;
    [SerializeField] private int bombCount;

    [SerializeField] private float radius = 0.75f;
    
    [SerializeField] private bool secretCoin;
    [SerializeField] private Vector3 secretCoinLocation = new Vector3(-51.4f, 21.3f, 0);

    private void Start()
    {
        int totalCoins = coinCount;
        if (GameManager.Instance != null)
        {
            GameManager.Instance.SetTotalCoins(totalCoins);
        }

        SpawnObjects(coinPrefab, coinCount);
        SpawnObjects(bombPrefab, bombCount);
        OnSecretCoin();
    }

    private void SpawnObjects(GameObject prefab, int value)
    {
        if (prefab == null) return;
        if (secretCoin) value = value -1;
        
        int spawned = 0;
        int attempts = 0;
        int maxAttempts = value * 5;
        
        while (spawned < value && attempts < maxAttempts)
        {
            attempts++;

            Vector3 pos = GetRandomVector();

            if (!Physics.CheckSphere(pos, radius))
            {
                Instantiate(prefab, pos, Quaternion.Euler(0, Random.Range(0f, 360f), 0));
                spawned++;
            }
        }
    }

    private void OnSecretCoin()
    {
        if (secretCoin && coinPrefab != null)
        {
            Instantiate(coinPrefab, secretCoinLocation, Quaternion.identity);
        }
    }
    
    private Vector3 GetRandomVector()
    {
        Vector3 pos = new Vector3(Random.Range(minSpawnBounds.x, maxSpawnBounds.x), Random.Range(minSpawnBounds.y, maxSpawnBounds.y), 0);
        return pos;
    }
}