using UnityEngine;

public class HelicopterSpawner : MonoBehaviour
{
    public GameObject[] helicopters; // те же вертолёты что и в меню

    private void Start()
    {
        if (helicopters == null || helicopters.Length == 0)
        {
            return;
        }

        // выключаем все
        for (int i = 0; i < helicopters.Length; i++)
        {
            helicopters[i].SetActive(false);
        }

        // читаем сохранённый выбор и включаем нужный
        int selected = Mathf.Clamp(HelicopterSelectionService.GetSelectedIndex(), 0, helicopters.Length - 1);
        helicopters[selected].SetActive(true);

        // Сообщаем всем подписчикам (например, камере) новую активную цель.
        HelicopterEvents.OnActiveHelicopterChanged?.Invoke(helicopters[selected].transform);
    }
}
