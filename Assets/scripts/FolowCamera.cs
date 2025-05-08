using UnityEngine;

public class SideViewCamera : MonoBehaviour
{
    public Transform target;     // Цель, за которой следует камера (вертолет)
    public Vector3 offset = new Vector3(-10f, 3f, 0f); // Смещение камеры
    public float smoothSpeed = 5f; // Скорость сглаживания

    void LateUpdate()
    {
        if (target == null)
            return;

        // Желаемая позиция камеры с учетом смещения
        Vector3 desiredPosition = target.position + offset;

        // Плавное перемещение камеры
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        transform.position = smoothedPosition;

        // Камера всегда смотрит в сторону движения (по z вперёд, так как вид сбоку)
        transform.LookAt(target.position + Vector3.forward * 10f);
    }
}