using UnityEngine;

public class HelicopterBounce : MonoBehaviour
{
    public float bounceForce;
    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bomb"))
        {
            Vector3 firstContact = collision.contacts[0].point;
            Vector3 bounceDerection = (transform.position - firstContact).normalized;
            _rb.linearVelocity = bounceDerection * bounceForce;
        }

    }
}
