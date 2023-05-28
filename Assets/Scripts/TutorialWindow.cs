using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TutorialWindow : MonoBehaviour
{
    public GameObject ModalWindowBox;
    public string text;
    public string confirmButton;
    public Sprite Image;
    public bool triggerOnEnable;
    public UnityAction ResumeGameAction;

  
    public void OnEnable ()
    {
        if (!triggerOnEnable) { return; }
        ResumeGameAction = new UnityAction(ResumeGame);
        UIController.Instance.modalWindow.Tutorial("Туториал", text, Image, "Продолжить", ResumeGameAction, null, null);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        ModalWindowBox.SetActive(false);
    }

}