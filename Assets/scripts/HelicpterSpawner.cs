using UnityEngine;

public static class HelicopterRuntimeState
{
    public static Transform ActiveHelicopter;
}

public class HelicpterSpawner : MonoBehaviour
{
    public GameObject[] helicopters;

    private void Start()
    {
        if (helicopters == null || helicopters.Length == 0)
        {
            return;
        }

        for (int i = 0; i < helicopters.Length; i++)
        {
            helicopters[i].SetActive(false);
        }

        int selected = Mathf.Clamp(HelicopterSelectionService.GetSelectedIndex(), 0, helicopters.Length - 1);
        helicopters[selected].SetActive(true);

        HelicopterRuntimeState.ActiveHelicopter = helicopters[selected].transform;
        HelicopterEvents.OnActiveHelicopterChanged?.Invoke(HelicopterRuntimeState.ActiveHelicopter);
    }
}
