using System.Collections.Generic;
using UnityEngine;

public class ExplosionPool : MonoBehaviour
{
    public static ExplosionPool Instance;

    [SerializeField] private ParticleSystem explosionPrefab;
    [SerializeField] private int poolSize = 10;

    private Queue<ParticleSystem> pool = new Queue<ParticleSystem>();

    private void Awake()
    {
        Instance = this;
        
        for (int i = 0; i < poolSize; i++)
        {
            var ps = Instantiate(explosionPrefab);
            ps.gameObject.SetActive(false);
            pool.Enqueue(ps);
        }
    }

    public void PlayExplosion(Vector3 position)
    {
        var ps = pool.Dequeue();

        ps.transform.position = position;
        ps.gameObject.SetActive(true);
        ps.Play();

        StartCoroutine(ReturnToPool(ps));

        pool.Enqueue(ps);
    }

    private System.Collections.IEnumerator ReturnToPool(ParticleSystem ps)
    {
        yield return new WaitForSeconds(ps.main.duration);

        ps.gameObject.SetActive(false);
    }
}