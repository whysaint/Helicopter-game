using System;
using UnityEngine;
using UnityEngine.Pool;
using System.Collections;
using UnityEngine.ParticleSystemJobs;

public class ExplosionPool : MonoBehaviour
{
    public static ExplosionPool Instance;
    
    [SerializeField] private ParticleSystem explosionPrefab;
    [SerializeField] private int poolSize = 10;
    
    private ObjectPool<ParticleSystem> _pool;

    private void Awake()
    {
        Instance = this;

        _pool = new ObjectPool<ParticleSystem>(
            CreateFunc,
            actionOnGet: (_pool) => _pool.gameObject.SetActive(true),
            actionOnRelease: (_pool) => _pool.gameObject.SetActive(false),
            actionOnDestroy: (_pool) => Destroy(_pool.gameObject),
            collectionCheck: false,
            defaultCapacity: poolSize,
            maxSize: poolSize
        );
    }

    private void Start()
    {
        int initialCount = 4;

        var tempArray = new ParticleSystem[initialCount];

        for (int i = 0; i < initialCount; i++)
        {
            tempArray[i] = _pool.Get();
        }
        
        for (int i = 0; i < initialCount; i++)
        {
            _pool.Release(tempArray[i]);
        }
    }

    private ParticleSystem CreateFunc()
    {
        ParticleSystem particle = Instantiate(explosionPrefab);
        return particle;
    }

    public void PlayExplosion(Vector3 position)
    {
        var pool = _pool.Get();
        pool.transform.position = position;
        StartCoroutine(PoolRetern(pool));
    }

    IEnumerator PoolRetern(ParticleSystem ps)
    {
        yield return new WaitForSeconds(ps.main.duration);
        _pool.Release(ps);
    }
}