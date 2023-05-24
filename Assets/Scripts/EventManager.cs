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
        GameObject eventInstance = Instantiate(eventToSpawn.eventPrefab, transform.position, transform.rotation);

        // Проверяем, является ли событие объектом с компонентом, отображающим текст
        EventTextDisplay eventTextDisplay = eventInstance.GetComponent<EventTextDisplay>();
        if (eventTextDisplay != null)
        {
            // Выбираем случайное описание события из массива
            string randomDescription = eventToSpawn.eventDescriptions[Random.Range(0, eventToSpawn.eventDescriptions.Length)];
            eventTextDisplay.ShowEventText(randomDescription, eventToSpawn.displayDuration);
        }
    }
}

[System.Serializable]
public class GameEvent
{
    public GameObject eventPrefab; // Префаб игрового события
    public string[] eventDescriptions; // Массив текстовых описаний для события
    public float displayDuration = 2f; // Продолжительность отображения текста
    // Дополнительные параметры и логика события
    // ...
}

[System.Serializable]
public class AmbulanceEvent : GameEvent
{
    // Дополнительные параметры и логика для ивента "Скорая помощь"
    // ...
}

[System.Serializable]
public class FirefightersEvent : GameEvent
{
    // Дополнительные параметры и логика для ивента "Пожарные"
    // ...
}

[System.Serializable]
public class PoliceEvent : GameEvent
{
    // Дополнительные параметры и логика для ивента "Полиция"
    // ...
}

public class EventTextDisplay : MonoBehaviour
{
    public TextMesh eventText; // Ссылка на компонент TextMesh для отображения текста

    private void Start()
    {
        eventText.gameObject.SetActive(false); // Изначально скрываем текст
    }

    public void ShowEventText(string text, float duration)
    {
        eventText.text = text; // Устанавливаем текст, который нужно отобразить
        eventText.gameObject.SetActive(true); // Показываем текст

        // Запускаем корутину, чтобы скрыть текст через заданную продолжительность
        StartCoroutine(HideEventTextCoroutine(duration));
    }

    private IEnumerator HideEventTextCoroutine(float duration)
    {
        yield return new WaitForSeconds(duration);
        eventText.gameObject.SetActive(false); // Скрываем текст
    }
}
