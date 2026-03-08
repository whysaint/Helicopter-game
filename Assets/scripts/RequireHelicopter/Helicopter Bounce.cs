using UnityEngine;

public class HelicopterBounce : MonoBehaviour
{
    [SerializeField] private float bounceForce;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag(GameTags.Bomb)) return;
        if (_rb == null) return;
        if (collision.contactCount == 0) return;
        
        Vector3 firstContact = collision.contacts[0].point;
        Vector3 bounceDirection = (transform.position - firstContact).normalized;
        _rb.linearVelocity = bounceDirection * bounceForce;
    }
}
