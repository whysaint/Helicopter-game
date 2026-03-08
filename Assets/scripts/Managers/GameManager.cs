using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Game Settings")]
    [SerializeField] private int totalCoinsToWin = 10;

    [Header("UI (optional)")]
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;

    private bool _isGameOver;

    public bool IsGameOver => _isGameOver;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        Coin.coinCount = 0;
        _isGameOver = false;
        Time.timeScale = 1f;
        HidePanels();
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    public void SetTotalCoins(int count)
    {
        totalCoinsToWin = count;
    }

    public void OnCoinCollected()
    {
        if (_isGameOver) return;
        if (Coin.coinCount >= totalCoinsToWin)
        {
            OnWin();
        }
    }

    public void OnWin()
    {
        if (_isGameOver) return;
        _isGameOver = true;
        Time.timeScale = 0f;

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlaySound(SoundType.Win);
        }

        if (winPanel != null)
        {
            winPanel.SetActive(true);
        }
    }

    public void OnLose()
    {
        if (_isGameOver) return;
        _isGameOver = true;
        Time.timeScale = 0f;

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlaySound(SoundType.Lose);
        }

        if (losePanel != null)
        {
            losePanel.SetActive(true);
        }
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    private void HidePanels()
    {
        if (winPanel != null) winPanel.SetActive(false);
        if (losePanel != null) losePanel.SetActive(false);
    }
}
