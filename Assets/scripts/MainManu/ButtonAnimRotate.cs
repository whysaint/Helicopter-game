using UnityEngine;

public class ButtonAnimRotate : MonoBehaviour
{
    [SerializeField] public float speedRot;
    void Update()
    {
        transform.Rotate(0f, 0f, speedRot * Time.deltaTime);
    }
}
