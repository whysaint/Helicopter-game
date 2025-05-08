using UnityEngine;

public class HelicopterMover : MonoBehaviour
{
    public float SpeedMove;
    public float SpeedRotate;
    public float StabilityForce = 3.5f;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        _rb.AddRelativeForce(0f, Input.GetAxis("Vertical") * SpeedMove, 0f);
        _rb.AddTorque(0f, 0f, -Input.GetAxis("Horizontal") * SpeedRotate );
        Stabilize();
    }

    void Stabilize()
    {
        Vector3 currutUp = transform.up;
        Vector3 factUp = Vector3.up;
        Vector3 finalUp = Vector3.Cross(currutUp, factUp);
        _rb.AddTorque(finalUp * StabilityForce);
        
    }

}
