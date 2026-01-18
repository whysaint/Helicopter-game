using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class volumeSlider : MonoBehaviour, IPointerUpHandler
{
    public Slider slider;
    private void Start()
    {
        slider.onValueChanged.AddListener(ChangeValue);
        
        float savedVolume = PlayerPrefs.GetFloat("Volume", 1f);
        slider.value = savedVolume;

    }

    void ChangeValue(float value)
    {
        AudioManader.Instance.SetVolume(value);
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        EventSystem.current.SetSelectedGameObject(null);
    }
}
