using UnityEngine;

public class SelecterCharter : MonoBehaviour
{
    public GameObject[] Helicopters;
    public int Number;

    public void ChangeCharter(int Num)
    {
        for (int i = 0; i < Helicopters.Length; i++)
        {
            Helicopters[i].gameObject.SetActive(true);
        }
    }

}
