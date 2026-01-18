using UnityEngine;

public class HelicopterMover : MonoBehaviour
{
    public float SpeedMove;
    public float SpeedRotate;
    public float StabilityForce = 3.5f;
    private Rigidbody _rb;
    
    private float _verticalInput = 0f;
    private float _horizontalInput = 0f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float vertical = Input.GetAxis("Vertical") + _verticalInput;
        float horizontal = Input.GetAxis("Horizontal") + _horizontalInput;

        vertical = Mathf.Clamp(vertical, -1f, 1f);
        horizontal = Mathf.Clamp(horizontal, -1f, 1f);

        _rb.AddRelativeForce(0f, vertical * SpeedMove, 0f);
        _rb.AddTorque(0f, 0f, -horizontal * SpeedRotate);
        Stabilize();
    }

    void Stabilize()
    {
        Vector3 currutUp = transform.up;
        Vector3 factUp = Vector3.up;
        Vector3 finalUp = Vector3.Cross(currutUp, factUp);
        _rb.AddTorque(finalUp * StabilityForce);
    }
    
    public void SetVerticalInput(float value)
    {
        _verticalInput = value;
    }

    public void SetHorizontalInput(float value)
    {
        _horizontalInput = value;
    }

    public void ResetVerticalInput()
    {
        _verticalInput = 0f;
    }

    public void ResetHorizontalInput()
    {
        _horizontalInput = 0f;
    }

}
