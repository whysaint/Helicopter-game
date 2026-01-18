using System;
using Unity.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelSpawner : MonoBehaviour
{
    [SerializeField] public GameObject coinPrefab;
    [SerializeField] public GameObject bombPrefab;

    [SerializeField] public Vector3 minVectorBounse;
    [SerializeField] public Vector3 maxVertorBounse;

    [SerializeField] public int coinCount;
    [SerializeField] public int bombCount;

    [SerializeField] private float radius = 0.75f;
    
    [SerializeField] private bool secretCoin;
    [SerializeField] private Vector3 secretCoinLocation = new Vector3(-51.4f, 21.3f, 0);

    private void Start()
    {
        SpawnObjects(coinPrefab, coinCount);
        SpawnObjects(bombPrefab, bombCount);
        OnSecretCoin();
    }

    void SpawnObjects(GameObject prefab ,int value)
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
                Instantiate(prefab, pos, Quaternion.identity);
                spawned++;
            }
        }
    }

    void OnSecretCoin()
    {
        if (secretCoin)
        {
            Instantiate(coinPrefab, secretCoinLocation, Quaternion.identity);
        }
        else
        {
            Debug.Log("OnSecretCoin is off - (false)");
        }
    }
    
    Vector3 GetRandomVector()
    {
        Vector3 pos = new Vector3(Random.Range(minVectorBounse.x, maxVertorBounse.x), Random.Range(minVectorBounse.y, maxVertorBounse.y), 0);
        return pos;
    }
}