using UnityEngine;

public class ColliderRemover : MonoBehaviour
{
    private void Start()
    {
        Collider[] colliders = GetComponentsInChildren<Collider>(true);
        foreach (var col in colliders)
        {
            Destroy(col);
        }

        Collider2D[] colliders2D = GetComponentsInChildren<Collider2D>(true);
        foreach (var col2D in colliders2D)
        {
            Destroy(col2D);
        }
    }
}