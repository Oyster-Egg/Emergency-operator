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
    public UnityEvent onContinueEvent;
    public UnityEvent onCancelEvent;
    public UnityEvent onAlternateEvent;

    public UnityAction ResumeGameAction;
    public UnityAction CancelAction;
    public UnityAction AlternateAction;

   /* private void Awake()
    {
        ResumeGameAction = new UnityAction();
        CancelAction = new UnityAction();
        AlternateAction = new UnityAction();
    }*/
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Confirm()
    {
        onConfirmAction?.Invoke();
        UIController.Instance.modalWindow.DialogWindow("Входящий вызов:", text, confirmButton, declineButton, alternateButton, ResumeGameAction, CancelAction, AlternateAction);
    }
}
