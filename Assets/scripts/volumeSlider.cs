using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volumeSlider : MonoBehaviour
{
    public Slider slider;
    private void Start()
    {
        slider.onValueChanged.AddListener(ChangeValue);
        slider.value = 1f;
        
    }

    void ChangeValue(float value)
    {
        AudioManader.Instance.SetVolume(value);
    }
}
