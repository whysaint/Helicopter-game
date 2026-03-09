using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject loadingIcon;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject garageButton;
    
    [SerializeField] private AudioSource onClickButtonSound;

    public void OnClickPlay()
    {
        StartCoroutine(Load());
    }
    
    public void OnClickSettings()
    {
        if (settingsPanel != null) settingsPanel.SetActive(true);
    }
    
    public void OnClickGarage()
    {
        if (garageButton != null) garageButton.SetActive(true);
    }
    
    public void OnCloseSettings()
    {
        if (settingsPanel != null) settingsPanel.SetActive(false);
    }
    
    public void OnCloseGarage()
    {
        if (garageButton != null) garageButton.SetActive(false);
    }

    private IEnumerator Load()
    {
        if (loadingIcon != null) loadingIcon.SetActive(true);
        yield return null;
        SceneManager.LoadScene("1");
    }
}
