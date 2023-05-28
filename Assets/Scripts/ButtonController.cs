using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Button button; // Ссылка на кнопку
    public float minDelay = 2f; // Минимальное время задержки
    public float maxDelay = 5f; // Максимальное время задержки

    private float delay; // Время задержки до появления кнопки
    private float timer; // Таймер для отсчета времени

    private void Start()
    {
        // Генерируем случайное время задержки
        delay = Random.Range(minDelay, maxDelay);
        timer = 0f;

        // Скрываем кнопку при старте
        button.gameObject.SetActive(false);
    }

    private void Update()
    {
        // Увеличиваем таймер
        timer += Time.deltaTime;

        // Проверяем, достигло ли время задержки
        if (timer >= delay)
        {
            // Отображаем кнопку
            button.gameObject.SetActive(true);
            // Отключаем скрипт, чтобы кнопка больше не появлялась
            enabled = false;
        }
    }
}

