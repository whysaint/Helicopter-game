using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayUI : MonoBehaviour
{
    public GameObject replayButton;

    public void ShowReplay()
    {
        replayButton.SetActive(true);
    }

    public void ReplayScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
