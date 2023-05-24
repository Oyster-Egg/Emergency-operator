using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour
{
    public GameEvent[] gameEvents; // Массив разных игровых событий
    public float minDelay = 5f; // Минимальная задержка перед появлением события
    public float maxDelay = 10f; // Максимальная задержка перед появлением события

    private void Start()
    {
        StartCoroutine(SpawnRandomEventCoroutine());
    }

    private IEnumerator SpawnRandomEventCoroutine()
    {
        while (true)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            SpawnRandomEvent();
        }
    }

    private void SpawnRandomEvent()
    {
        if (gameEvents.Length == 0)
        {
            Debug.LogWarning("Массив игровых событий пуст.");
            return;
        }

        int randomIndex = Random.Range(0, gameEvents.Length);
        GameEvent eventToSpawn = gameEvents[randomIndex];

        // Создаем экземпляр игрового события
        Instantiate(eventToSpawn.eventPrefab, transform.position, transform.rotation);
    }
}

[System.Serializable]
public class GameEvent
{
    public GameObject eventPrefab; // Префаб игрового события
    // Дополнительные параметры и логика события
}

[System.Serializable]
public class AmbulanceEvent : GameEvent
{
    
}

