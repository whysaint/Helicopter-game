using UnityEngine;

public class CameraFollowWithBounds : MonoBehaviour
{
    public Transform target;                  // Игрок или цель
    public Vector3 offset = new Vector3(0f, 1f, -10f);  // Смещение камеры
    public float speed = 5f;                  // Скорость следования камеры

    public Vector2 minBounds;                 // Минимальные границы (X, Y)
    public Vector2 maxBounds;                 // Максимальные границы (X, Y)

    private bool isFollowing = true;          // Следует ли камера за игроком

    void LateUpdate()
    {
        // Проверка, находится ли игрок внутри границ
        if (target.position.x > minBounds.x && target.position.x < maxBounds.x &&
            target.position.y > minBounds.y && target.position.y < maxBounds.y)
        {
            isFollowing = true;
        }
        else
        {
            isFollowing = false;
        }

        // Если игрок внутри границ — камера следует за ним
        if (isFollowing)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, speed * Time.deltaTime);
            transform.position = smoothedPosition;

            // Если хочешь, чтобы камера всегда смотрела на игрока
            // transform.LookAt(target);
        }
    }
}