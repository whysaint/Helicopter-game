using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayTest : MonoBehaviour
{
    [SerializeField] private GameObject loadingIcon;

    public void OnClick()
    {
        StartCoroutine(Load());
    }

    IEnumerator Load()
    {
        loadingIcon.SetActive(true);
        yield return null;
        SceneManager.LoadScene("1");
    }
}