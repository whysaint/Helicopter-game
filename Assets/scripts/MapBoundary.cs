using UnityEngine;

/// <summary>
/// Толкает игрока вниз при выходе за границы карты (триггер).
/// ИСПРАВЛЕНО: null-проверка FindObjectOfType, проверка other — сила применяется только к Player.
/// </summary>
public class MapBoundary : MonoBehaviour
{
    public float forceBackInMap = 5f;
    private Rigidbody _playerRigidbody;

    private void Start()
    {
        // ДОБАВЛЕНО: проверка результата FindObjectOfType на null
        // ПОЧЕМУ: FindObjectOfType возвращает null, если объект не найден (удалён, не загружен). .GetComponent вызывал NullReferenceException.
        // КАК ИЗБЕЖАТЬ: Всегда проверяй результат FindObjectOfType/FindObjectOfType перед вызовом методов.
        HelicopterMover helicopter = FindObjectOfType<HelicopterMover>();
        if (helicopter != null)
        {
            _playerRigidbody = helicopter.GetComponent<Rigidbody>();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (_playerRigidbody == null) return;
        // ДОБАВЛЕНО: проверка other.CompareTag("Player")
        // ПОЧЕМУ: В триггер заходит любой объект с коллайдером. Раньше сила применялась ко всем — NPC, монеты и т.д. двигались.
        // КАК ИЗБЕЖАТЬ: В OnTriggerEnter/Stay/Exit всегда проверяй, что other — нужный объект (тег, слой, или GetComponent).
        if (!other.transform.root.CompareTag(GameTags.Player)) return;
        
        _playerRigidbody.AddForce(Vector3.down * forceBackInMap * Time.deltaTime);
    }
}
