using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    public int countCoin;
    public AudioSource coinSound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("COIN"))
        {
            countCoin++;
            Destroy(other.gameObject);
            coinSound.Play();
        }
    }
}
