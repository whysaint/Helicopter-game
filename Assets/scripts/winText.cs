using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class winText : MonoBehaviour
{
    public GameObject canvass;
    public Text textQ;
    private int count;
    private int coinCountSYKA;
    void Start()
    {
        textQ = GetComponent<Text>();
        canvass.SetActive(false);
    }
    
    void Update()
    {
        coinCountSYKA = GameObject.FindGameObjectsWithTag("COIN").Length;
        if (coinCountSYKA == 0)
        {
            canvass.SetActive(true);
        }
        Debug.LogError($"Осталось монет {coinCountSYKA}");
    }
}
