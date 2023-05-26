using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallController : MonoBehaviour
{
    public GameObject panel; // ������ �� ������
    public Button button;

    public void TogglePanel()
    {
        panel.SetActive(!panel.activeSelf);
        button.gameObject.SetActive(!panel.activeSelf);
    }
}

