using UnityEngine;

public class HelicopterMover : MonoBehaviour
{
    [SerializeField] private float speedMove = 10f;
    [SerializeField] private float speedRotate = 5f;
    [SerializeField] private float stabilityForce = 3.5f;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (InputManager.Instance == null || _rb == null) return;
        
        float vertical = InputManager.Instance.Vertical;
        float horizontal = InputManager.Instance.Horizontal;
        
        _rb.AddRelativeForce(0f, vertical * speedMove, 0f);
        _rb.AddTorque(0f, 0f, -horizontal * speedRotate);
        Stabilize();
    }

    void Stabilize()
    {
        Vector3 currentUp = transform.up;
        Vector3 worldUp = Vector3.up;
        Vector3 finalUp = Vector3.Cross(currentUp, worldUp);
        _rb.AddTorque(finalUp * stabilityForce);
    }

    public float GetMagnitude()
    {
        float speed = _rb.linearVelocity.magnitude;
        return Mathf.Clamp01(speed / 15f);
    }
}