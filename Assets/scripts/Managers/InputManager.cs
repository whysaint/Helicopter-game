using UnityEngine;
using System;

public class InputManager : MonoBehaviour
{
    private static InputManager _instance;
    public static InputManager Instance => _instance;
    
    public event Action<float> OnVerticalInput;
    public event Action<float> OnHorizontalInput;
    
    public float Vertical { get; private set; }
    public float Horizontal { get; private set; }
    
    private float _uiVertical = 0f;
    private float _uiHorizontal = 0f;
    
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = null;
        }
    }
    
    private void Update()
    {

        Vertical = Mathf.Clamp(Input.GetAxis("Vertical") + _uiVertical, -1f, 1f);
        Horizontal = Mathf.Clamp(Input.GetAxis("Horizontal") + _uiHorizontal, -1f, 1f);
        

        OnVerticalInput?.Invoke(Vertical);
        OnHorizontalInput?.Invoke(Horizontal);
    }
    
    public void SetVerticalUI(float value)
    {
        _uiVertical = value;
    }
    
    public void SetHorizontalUI(float value)
    {
        _uiHorizontal = value;
    }
    
    public void ResetVerticalUI()
    {
        _uiVertical = 0f;
    }
    
    public void ResetHorizontalUI()
    {
        _uiHorizontal = 0f;
    }
}