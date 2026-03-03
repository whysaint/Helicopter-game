using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IUManager : MonoBehaviour
{
    [SerializeField] private GameObject loadingIcon;
    [SerializeField] private GameObject sattingsPanel;
    [SerializeField] private GameObject garageButton;
    
    [SerializeField] private AudioSource OnClickButtonSound;

    public void OnClickplay()
    {
        StartCoroutine(Load());
    }
    
    public void OnClickSattings()
    {
        sattingsPanel.SetActive(true);
    }
    
    public void OnClickGarage()
    {
        garageButton.SetActive(true);
    }
    
    public void OnCloseSattings()
    {
        sattingsPanel.SetActive(false);
    }
    
    public void OnCloseGarage()
    {
        garageButton.SetActive(false);
    }

    public void OnClickButtonSoundPlay()
    {
        OnClickButtonSound.Play();
    }

    IEnumerator Load()
    {
        loadingIcon.SetActive(true);
        yield return null;
        SceneManager.LoadScene("1");
    }
}
