using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static int testFPSCoinSountWithoutFindObjectsOfTypeNahuiChoYaVoobchePisalBlat = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            testFPSCoinSountWithoutFindObjectsOfTypeNahuiChoYaVoobchePisalBlat++;
            Debug.Log(testFPSCoinSountWithoutFindObjectsOfTypeNahuiChoYaVoobchePisalBlat);
            
            Destroy(gameObject);
            AudioManader.Instance.PlaySound(Soundtype.Coin);
        }
    }
}
