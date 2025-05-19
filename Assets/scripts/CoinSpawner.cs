using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public GameObject bombPrefab;
    public float minZonaX;
    public float maxZonaX;
    public float minZonaY;
    public float maxZonaY;
    
    public float CoinCountValueSpawn;
    public float BombCountValueSpawn;

    private void Start()
    {
        for (int i = 0; i < CoinCountValueSpawn; i++)
        {
            Vector2 spawnZone = new Vector2(Random.Range(minZonaX, maxZonaX), Random.Range(minZonaY, maxZonaY));
            Instantiate(coinPrefab, spawnZone, Quaternion.identity);
        }
        
        for (int i = 0; i < BombCountValueSpawn; i++)
        {
            Vector2 spawnZone = new Vector2(Random.Range(minZonaX, maxZonaX), Random.Range(minZonaY, maxZonaY));
            Instantiate(bombPrefab, spawnZone, Quaternion.identity);
        }

        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
}