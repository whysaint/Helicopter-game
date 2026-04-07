using UnityEngine;

public class SelecterCharter : MonoBehaviour
{
    public GameObject[] helicopters;
    public int number;

    private void Start()
    {
        if (helicopters == null || helicopters.Length == 0)
        {
            return;
        }

        number = Mathf.Clamp(HelicopterSelectionService.GetSelectedIndex(), 0, helicopters.Length - 1);

        for (int i = 0; i < helicopters.Length; i++)
        {
            helicopters[i].SetActive(false);
        }

        helicopters[number].SetActive(true);
    }

    public void ChangeCharter(int num)
    {
        if (helicopters == null || helicopters.Length == 0)
        {
            return;
        }

        for (int i = 0; i < helicopters.Length; i++)
        {
            helicopters[i].SetActive(false);
        }

        number += num;

        if (number > helicopters.Length - 1)
        {
            number = 0;
        }
        
        if (number < 0)
        {
            number = helicopters.Length - 1;
        }
        
        helicopters[number].SetActive(true);

        HelicopterSelectionService.SetSelectedIndex(number);
    }
}
