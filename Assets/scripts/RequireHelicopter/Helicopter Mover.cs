using UnityEngine;

public class HelicopterMover : MonoBehaviour
{
    public float speedMove = 10f;
    public float speedRotate = 5f;
    public float stabilityForce = 3.5f;
    public Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float vertical = InputManager.Instance.Vertical;
        float horizontal = InputManager.Instance.Horizontal;
        
        _rb.AddRelativeForce(0f, vertical * speedMove, 0f);
        _rb.AddTorque(0f, 0f, -horizontal * speedRotate);
        Stabilize();
    }

    void Stabilize()
    {
        Vector3 currutUp = transform.up;
        Vector3 factUp = Vector3.up;
        Vector3 finalUp = Vector3.Cross(currutUp, factUp);
        _rb.AddTorque(finalUp * stabilityForce);
    }

    public float GetMagnitude()
    {
        float speed = _rb.linearVelocity.magnitude;
        return Mathf.Clamp01(speed / 15f);
    }
}