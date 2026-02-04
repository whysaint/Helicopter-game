using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayTest : MonoBehaviour
{
    [SerializeField] private GameObject g;
    
    public void OnClick()
    {
        g.SetActive(true);
        SceneManager.LoadScene("1");
    }
    
}
