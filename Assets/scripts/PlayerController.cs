using System;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    private IHelicopterInput currentHelicopter;

    private void Start()
    {
        HelicopterMover heli = FindObjectOfType<HelicopterMover>();
        SetActiveHelicopter(heli);
    }

    public void SetActiveHelicopter(IHelicopterInput helicopter)
    {
        currentHelicopter = helicopter;
        if (helicopter == null)
        {
            Debug.Log("shit code");
        }
    }
    
    public void VerticalPlus()
    {
        Debug.Log("VerticalPlus called");
        currentHelicopter?.VerticalInput(1f); //up
    }
    
    public void VerticalMinus()
    {
        currentHelicopter?.VerticalInput(-1f); //down
    }

    public void ResetVertical()
    {
        currentHelicopter?.ResetVerticalInput();
    }

    public void HorizontalPlus()
    {
        currentHelicopter?.HorizontalInput(1f); //left
    }

    public void HorizontalMinus()
    {
        currentHelicopter?.HorizontalInput(-1f);// right 
    }

    public void ResetHorizontal()
    {
        currentHelicopter?.ResetHorizontalInput();
    }
}
