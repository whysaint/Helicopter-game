using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    public void VerticalPlus()
    {
        InputManager.Instance.SetVerticalUI(1f);
    }
    
    public void VerticalMinus()
    {
        InputManager.Instance.SetVerticalUI(-1f);
    }

    public void ResetVertical()
    {
        InputManager.Instance.ResetVerticalUI();
    }

    public void HorizontalPlus()
    {
        InputManager.Instance.SetHorizontalUI(1f);
    }

    public void HorizontalMinus()
    {
        InputManager.Instance.SetHorizontalUI(-1f);
    }

    public void ResetHorizontal()
    {
        InputManager.Instance.ResetHorizontalUI();
    }
}