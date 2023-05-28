using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CallsScript : MonoBehaviour
{
    private Action onConfirmAction;

    public string text;
    public string confirmButton;
    public string declineButton;
    public string alternateButton;

    public UnityAction ResumeGameAction;
    public UnityAction CancelAction;
    public UnityAction AlternateAction;

    public string[] Astrings; // Assign the possible strings in the inspector
    public string[] Fstrings; // Assign the possible strings in the inspector
    public string[] Gstrings; // Assign the possible strings in the inspector
    public string[] Pbstrings; // Assign the possible strings in the inspector
    public string[] Psstrings; // Assign the possible strings in the inspector
    public string[] Hstrings; 
    public string[] Nullstrings; // Assign the possible strings in the inspector
    private string randomString; // Store the random picked string

    /* private void Awake()
     {
         ResumeGameAction = new UnityAction();
         CancelAction = new UnityAction();
         AlternateAction = new UnityAction();
     }*/
    // Start is called before the first frame update
    void Start()
    {
        // Get a random index between 0 and the length of the array
        //int index = Random.Range(0, Astrings.Length);

        // Get the string at that index
       // randomString = Astrings[index];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Confirm()
    {
        onConfirmAction?.Invoke();
        Time.timeScale = 0;
        UIController.Instance.modalWindow.DialogWindow("Входящий вызов:", text, "Отправить машину", "Первая помощь", "Положить трубку", ResumeGameAction, CancelAction, AlternateAction);
    }
}
