using UnityEngine;

public class ColliderRemover : MonoBehaviour
{
    void Start()
    {
        Collider[] colliders = GetComponentsInChildren<Collider>(true);
        foreach (var col in colliders)
        {
            DestroyImmediate(col);
        }

        Collider2D[] colliders2D = GetComponentsInChildren<Collider2D>(true);
        foreach (var col2D in colliders2D)
        {
            DestroyImmediate(col2D);
        }

        Debug.Log("Удалены все коллайдеры и 2D-коллайдеры.");
    }
}