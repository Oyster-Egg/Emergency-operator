using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel; // ������ �� ������ ����� � Unity

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
        pausePanel.SetActive(true); // ���������� ������ �����
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        pausePanel.SetActive(false); // �������� ������ �����
    }
}

