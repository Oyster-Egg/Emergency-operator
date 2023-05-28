using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ModalWindowPanel : MonoBehaviour
{
    public GameObject ModalWindowBox;
    [SerializeField]
    private Image _background;
    [Header("Header")]
    [SerializeField]
    private Transform _headerArea;
    [SerializeField]
    private TextMeshProUGUI _titleField;

    [Header("Content")]
    [SerializeField]
    private Transform _contentArea;
    [SerializeField]
    private Transform _verticalLayoutArea;
    [SerializeField]
    private Image _heroImage;
    [SerializeField]
    private TextMeshProUGUI _heroText;
    [Space()]
    [SerializeField]
    private Transform _horizontalLayoutArea;
    [SerializeField]
    private Transform _iconContainer;
    [SerializeField]
    private Image _iconImage;
    [SerializeField]
    private TextMeshProUGUI _iconText;

    [Header("Footer")]
    [SerializeField]
    private Transform _footerArea;
    [SerializeField]
    private Button _confirmButton;
    [SerializeField]
    private TextMeshProUGUI _confirmButtonText;
    [SerializeField]
    private Button _declineButton;
    [SerializeField]
    private TextMeshProUGUI _declineButtonText;
    [SerializeField]
    private Button _alternateButton;
    [SerializeField]
    private TextMeshProUGUI _alternateButtonText;

    private Action onConfirmAction;
    private Action onDeclineAction;
    private Action onAlternateAction;


    public void Confirm()
    {
        onConfirmAction?.Invoke();
        Close();
    }
    public void Decline()
    {
        onDeclineAction?.Invoke();
        Close();
    }
    public void Alternate()
    {
        onAlternateAction?.Invoke();
        Close();
    }
    public void Close()
    {
        ModalWindowBox.SetActive(false);
    }

    public void PauseMenu(string title,string confirmButton, string declineButton, string alternateButton, UnityAction confirmAction, UnityAction declineAction, UnityAction alternateAction = null)
    {
        ModalWindowBox.SetActive(true);
       Color color = _background.color;
        color.a = 0;
        _background.color = color;
        _horizontalLayoutArea.gameObject.SetActive(false);
        _verticalLayoutArea.gameObject.SetActive(false);
        bool hasTitle = string.IsNullOrEmpty(title);
        _headerArea.gameObject.SetActive(hasTitle);
        _titleField.text = title;
        if (confirmAction != null)
        {
            _confirmButton.gameObject.SetActive(true);
            _confirmButtonText.text = confirmButton;
            _confirmButton.onClick.AddListener(new UnityAction(confirmAction));
        }
        if (declineAction != null)
        {
            _declineButton.gameObject.SetActive(true);
            _declineButtonText.text = declineButton;
            _declineButton.onClick.AddListener(new UnityAction(declineAction));
        }
        if (alternateAction != null)
        {
            _alternateButton.gameObject.SetActive(false);
            _alternateButtonText.text = alternateButton;
            _alternateButton.onClick.AddListener(new UnityAction(alternateAction));
        }
    }
    public void DialogWindow(string title,string text, string confirmButton, string declineButton, string alternateButton, UnityAction confirmAction, UnityAction declineAction, UnityAction alternateAction = null)
    {
        ModalWindowBox.SetActive(true);
        Color color = _background.color;
        color.a = 1;
        _background.color = color;
        _horizontalLayoutArea.gameObject.SetActive(false);
        _verticalLayoutArea.gameObject.SetActive(true);
        _headerArea.gameObject.SetActive(true);
        _titleField.text = title;
        _contentArea.gameObject.SetActive(true);
        _heroText.text = text;
        if (confirmAction != null)
        {
            _confirmButton.gameObject.SetActive(true);
            _confirmButtonText.text = confirmButton;
            _confirmButton.onClick.AddListener(new UnityAction(confirmAction));
        }
        if (declineAction != null)
        {
            _declineButton.gameObject.SetActive(true);
            _declineButtonText.text = declineButton;
            _declineButton.onClick.AddListener(new UnityAction(declineAction));
        }
        if (alternateAction != null)
        {
            _alternateButton.gameObject.SetActive(true);
            _alternateButtonText.text = alternateButton;
            _alternateButton.onClick.AddListener(new UnityAction(alternateAction));
        }
    }
    public void Tutorial (string title, string text, Sprite Image, string confirmButton, UnityAction confirmAction, UnityAction declineAction, UnityAction alternateAction = null)
    {
        ModalWindowBox.SetActive(true);
        Color color = _background.color;
        color.a = 1;
        _background.color = color;
        _horizontalLayoutArea.gameObject.SetActive(true);
        _verticalLayoutArea.gameObject.SetActive(false);
        _contentArea.gameObject.SetActive(true);
        bool hasTitle = string.IsNullOrEmpty(title);
        _headerArea.gameObject.SetActive(hasTitle);
        _iconImage.sprite = Image;
        _titleField.text = title;
        _iconText.text = text;
        _declineButton.gameObject.SetActive(false);
        _alternateButton.gameObject.SetActive(false);
        if (confirmAction != null)
        {
            _confirmButton.gameObject.SetActive(true);
            _confirmButtonText.text = confirmButton;
            _confirmButton.onClick.AddListener(new UnityAction(confirmAction));
        }
        
    }
}
