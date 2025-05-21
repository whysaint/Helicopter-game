    using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    public int countCoin;
    public int maxCoinsInGame;
    public TextMeshProUGUI coitText;
    public AudioSource coinSound;
    void Start()
    {
        maxCoinsInGame = GameObject.FindGameObjectsWithTag("COIN").Length;
    }

    void Update()
    {
        UpdateCoinText();
    }

    public void AddCoin(int amount)
    {
        countCoin += amount;
    }

    void UpdateCoinText()
    {
        coitText.text = $"Coins: {countCoin}/{maxCoinsInGame}";
    }

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
