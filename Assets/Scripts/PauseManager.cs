using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel; // —сылка на панель паузы в Unity

    private bool isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
        pausePanel.SetActive(true); // ќтображаем панель паузы
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        pausePanel.SetActive(false); // —крываем панель паузы
    }
}

