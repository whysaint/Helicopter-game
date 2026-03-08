using UnityEngine;

public class MapBoundary : MonoBehaviour
{
    public float forceBackInMap = 5f;
    private Rigidbody _playerRigidbody;

    private void Start()
    {
        HelicopterMover helicopter = FindObjectOfType<HelicopterMover>();
        if (helicopter != null)
        {
            _playerRigidbody = helicopter.GetComponent<Rigidbody>();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (_playerRigidbody == null) return;
        
        if (!other.transform.root.CompareTag(GameTags.Player)) return;
        
        _playerRigidbody.AddForce(Vector3.down * forceBackInMap * Time.deltaTime);
    }
}
