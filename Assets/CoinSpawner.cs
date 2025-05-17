using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public float minZonaX;
    public float maxZonaX;
    public float minZonaY;
    public float maxZonaY;
    public float CoinValueSpawn;

    private void Start()
    {
        for (int i = 0; i < CoinValueSpawn; i++)
        {
            Vector2 spawnZone = new Vector2(Random.Range(minZonaX, maxZonaX), Random.Range(minZonaY, maxZonaY));
            Instantiate(coinPrefab, spawnZone, Quaternion.identity);
        }
    }

    private void Update()
    {
        /*Vector2 spawnZone = new Vector2(Random.Range(minZonaY, maxZonaY), Random.Range(minZonaX, maxZonaX));
        
        for (int i = 0; i < CoinValueSpawn; i++)
        {
            Instantiate(coinPrefab, spawnZone, Quaternion.identity);
        }*/
    }
}
