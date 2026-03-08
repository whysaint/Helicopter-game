using UnityEngine;

public class ButtonAnimRotate : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0f, 0f, -100f * Time.deltaTime);
    }
}
