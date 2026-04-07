using UnityEngine;

public static class HelicopterSelectionService
{
    private const string SelectedHelicopterKey = "SelectedHelicopter";

    public static int GetSelectedIndex()
    {
        return PlayerPrefs.GetInt(SelectedHelicopterKey, 0);
    }

    public static void SetSelectedIndex(int index)
    {
        PlayerPrefs.SetInt(SelectedHelicopterKey, index);
        PlayerPrefs.Save();
    }
}
