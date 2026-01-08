using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// Простая, надёжная реализация спавнера для 3D-проекта.
/// - область задаётся двумя Vector3 (minBounds, maxBounds)
/// - проверка свободного места через Physics.CheckSphere + LayerMask
/// - ограничение попыток, чтобы не застрять в бесконечном цикле
/// - DrawGizmos для визуализации области
/// </summary>
public class LevelSpawner : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private GameObject bombPrefab;

    [Header("Spawn area (3D)")]
    [Tooltip("Minimum corner (x,y,z) of the spawn box")]
    [SerializeField] private Vector3 minBounds = new Vector3(-5f, 0.5f, -5f);
    [Tooltip("Maximum corner (x,y,z) of the spawn box")]
    [SerializeField] private Vector3 maxBounds = new Vector3(5f, 1f, 5f);

    [Header("Counts")]
    [SerializeField] private int coinCount = 10;
    [SerializeField] private int bombCount = 3;

    [Header("Spawn checks")]
    [Tooltip("Radius used to check if space is free for spawning")]
    [SerializeField] private float checkRadius = 0.5f;
    [Tooltip("Which layers block spawning (e.g. Obstacles). Do NOT include Ground if you want to ignore it.")]
    [SerializeField] private LayerMask spawnBlockMask = ~0; // by default checks everything
    [Tooltip("How many attempts to try per object before giving up")]
    [SerializeField] private int maxAttemptsPerObject = 30;

    [Header("Behaviour")]
    [SerializeField] private bool spawnOnStart = true;
    [SerializeField] private bool logWarnings = true;

    private void Start()
    {
        if (spawnOnStart)
        {
            SpawnLevel();
        }
    }

    /// <summary>
    /// Public entry point: spawn coins and bombs according to inspector values.
    /// </summary>
    public void SpawnLevel()
    {
        Debug.Log("LevelSpawner: SpawnLevel()");
        SpawnObjects(coinPrefab, coinCount);
        SpawnObjects(bombPrefab, bombCount);
    }

    /// <summary>
    /// Spawns 'count' copies of prefab, trying up to maxAttemptsPerObject for each.
    /// If spawnBlockMask == 0, no physics check is performed (always spawns).
    /// </summary>
    private void SpawnObjects(GameObject prefab, int count)
    {
        if (prefab == null)
        {
            if (logWarnings) Debug.LogWarning($"LevelSpawner: prefab is null, skipping spawn.");
            return;
        }

        if (count <= 0) return;

        for (int i = 0; i < count; i++)
        {
            bool spawned = false;

            for (int attempt = 0; attempt < Mathf.Max(1, maxAttemptsPerObject); attempt++)
            {
                Vector3 pos = GetRandomPosition();

                // If mask == 0, skip collision check (fast path)
                bool blocked = false;
                if (spawnBlockMask != 0)
                {
                    // Physics.CheckSphere expects a Vector3 position and radius.
                    blocked = Physics.CheckSphere(pos, checkRadius, spawnBlockMask);
                }

                if (!blocked)
                {
                    Instantiate(prefab, pos, Quaternion.identity);
                    spawned = true;
                    break;
                }
            }

            if (!spawned && logWarnings)
            {
                Debug.LogWarning($"LevelSpawner: failed to spawn '{prefab.name}' after {maxAttemptsPerObject} attempts.");
            }
        }
    }

    /// <summary>
    /// Returns a random Vector3 inside the axis-aligned box defined by minBounds and maxBounds.
    /// </summary>
    private Vector3 GetRandomPosition()
    {
        float x = Random.Range(minBounds.x, maxBounds.x);
        float y = Random.Range(minBounds.y, maxBounds.y);
        float z = Random.Range(minBounds.z, maxBounds.z);
        return new Vector3(x, y, z);
    }

    // Editor helper: draw spawn area box and sample points
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0f, 0.7f, 1f, 0.15f);
        Vector3 center = (minBounds + maxBounds) * 0.5f;
        Vector3 size = new Vector3(
            Mathf.Abs(maxBounds.x - minBounds.x),
            Mathf.Abs(maxBounds.y - minBounds.y),
            Mathf.Abs(maxBounds.z - minBounds.z)
        );

        Gizmos.DrawCube(center, size);
        Gizmos.color = new Color(0f, 0.7f, 1f, 0.9f);
        Gizmos.DrawWireCube(center, size);

        // draw sample spheres for radius
        Gizmos.color = Color.yellow;
        Vector3 sample = GetRandomPosition();
        Gizmos.DrawWireSphere(sample, checkRadius);
    }

    // Make sure min <= max — convenience in inspector
    private void OnValidate()
    {
        // swap if needed
        if (minBounds.x > maxBounds.x)
        {
            float t = minBounds.x; minBounds.x = maxBounds.x; maxBounds.x = t;
        }
        if (minBounds.y > maxBounds.y)
        {
            float t = minBounds.y; minBounds.y = maxBounds.y; maxBounds.y = t;
        }
        if (minBounds.z > maxBounds.z)
        {
            float t = minBounds.z; minBounds.z = maxBounds.z; maxBounds.z = t;
        }

        if (maxAttemptsPerObject < 1) maxAttemptsPerObject = 1;
        if (checkRadius < 0f) checkRadius = 0.01f;
        if (coinCount < 0) coinCount = 0;
        if (bombCount < 0) bombCount = 0;
    }
}
