using UnityEngine;

/// <summary>
/// Монета, собираемая игроком. Увеличивает счёт и вызывает победу при сборе всех.
/// ИСПРАВЛЕНО: убран Debug.LogWarning, добавлены null-проверки для Singleton.
/// </summary>
public class Coin : MonoBehaviour
{
    public static int coinCount = 0;
    
    [SerializeField] private Light _pointLight;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag(GameTags.Player))
        {
            coinCount++;
            Destroy(gameObject);
            if (_pointLight != null)
            {
                _pointLight.enabled = false;
            }
            
            // ДОБАВЛЕНО: проверка Instance != null
            // ПОЧЕМУ: Singleton может быть ещё не создан (порядок Awake) или уничтожен. Без проверки — NullReferenceException.
            // КАК ИЗБЕЖАТЬ: При обращении к Singleton всегда проверяй: if (XxxManager.Instance != null) XxxManager.Instance.DoThing();
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.PlaySound(SoundType.Coin);
            }

            if (GameManager.Instance != null)
            {
                GameManager.Instance.OnCoinCollected();
            }
        }
    }
}
