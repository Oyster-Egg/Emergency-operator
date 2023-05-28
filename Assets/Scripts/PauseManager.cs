using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject ModalWindowBox; // —сылка на панель паузы в Unity
    public string title;
    public string confirmButton;
    public string declineButton;
    public string alternateButton;

    public UnityAction ResumeGameAction;
    public UnityAction CancelAction;
    public UnityAction AlternateAction;



    private bool isPaused = false;
    
    private void Awake()
    {
        ResumeGameAction = new UnityAction(ResumeGame);
        CancelAction = new UnityAction(MainMenu);
        AlternateAction = new UnityAction(ResumeGame);
    }

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

        UIController.Instance.modalWindow.PauseMenu(title, confirmButton, declineButton, alternateButton, ResumeGameAction, CancelAction, AlternateAction);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        ModalWindowBox.SetActive(false);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

