using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Button button; // ������ �� ������
    public float minDelay = 2f; // ����������� ����� ��������
    public float maxDelay = 5f; // ������������ ����� ��������

    private float delay; // ����� �������� �� ��������� ������
    private float timer; // ������ ��� ������� �������

    private void Start()
    {
        // ���������� ��������� ����� ��������
        delay = Random.Range(minDelay, maxDelay);
        timer = 0f;

        // �������� ������ ��� ������
        button.gameObject.SetActive(false);
    }

    private void Update()
    {
        // ����������� ������
        timer += Time.deltaTime;

        // ���������, �������� �� ����� ��������
        if (timer >= delay)
        {
            // ���������� ������
            button.gameObject.SetActive(true);
            // ��������� ������, ����� ������ ������ �� ����������
            enabled = false;
        }
    }
}

