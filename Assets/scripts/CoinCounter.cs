using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    public int countCoin;
    public AudioSource coinSound;
    public AudioSource bombSound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("COIN"))
        {
            countCoin++;
            Destroy(other.gameObject);
            coinSound.Play();
        }
        if (other.gameObject.CompareTag("Bomb"))
        {
            bombSound.Play();
        }
    }
}
