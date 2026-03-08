using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private TMP_Text scoreTextTMP;

    private void Start()
    {
        if (scoreText == null) scoreText = GetComponent<Text>();
        UpdateScore(Coin.coinCount);
    }

    private void Update()
    {
        UpdateScore(Coin.coinCount);
    }

    private void UpdateScore(int score)
    {
        string scoreString = score.ToString();
        if (scoreText != null)
        {
            scoreText.text = scoreString;
        }
        if (scoreTextTMP != null)
        {
            scoreTextTMP.text = scoreString;
        }
    }
}
