using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    private IHelicopterInput _currentHelicopter;

    private void Start()
    {
        HelicopterMover heli = FindAnyObjectByType<HelicopterMover>();
        SetActiveHelicopter(heli);
    }

    public void SetActiveHelicopter(IHelicopterInput helicopter)
    {
        _currentHelicopter = helicopter;
        if (helicopter == null)
        {
            Debug.Log("shit code");
        }
    }
    
    public void VerticalPlus()
    {
        Debug.Log("VerticalPlus called");
        _currentHelicopter?.VerticalInput(1f); //up
    }
    
    public void VerticalMinus()
    {
        _currentHelicopter?.VerticalInput(-1f); //down
    }

    public void ResetVertical()
    {
        _currentHelicopter?.ResetVerticalInput();
    }

    public void HorizontalPlus()
    {
        _currentHelicopter?.HorizontalInput(1f); //left
    }

    public void HorizontalMinus()
    {
        _currentHelicopter?.HorizontalInput(-1f);// right 
    }

    public void ResetHorizontal()
    {
        _currentHelicopter?.ResetHorizontalInput();
    }
}
