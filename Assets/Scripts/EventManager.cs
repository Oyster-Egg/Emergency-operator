using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour
{
    private string[] gameEvents = new string[7] { "Ambulance", "Firetruck", "GasService", "PoliceBig", "PoliceSmall", "Decline", "Help" }; // ������ ������ ������� �������
    public float minDelay = 5f; // ����������� �������� ����� ���������� �������
    public float maxDelay = 10f; // ������������ �������� ����� ���������� �������
    private CallsScript callsScript;

    private void Start()
    {
        StartCoroutine(SpawnRandomEventCoroutine());
     
    }

    private IEnumerator SpawnRandomEventCoroutine()
    {
        while (true)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            SpawnRandomEvent();
        }
    }

    private void SpawnRandomEvent()
    {
        if (gameEvents.Length == 0)
        {
            Debug.LogWarning("������ ������� ������� ����.");
            return;
        }

        

       int randomIndex = Random.Range(0, gameEvents.Length);
        if (randomIndex == 0) 
        {
            CallsScript.Instance.AssignedWindow(randomIndex);
            CallsScript.Instance.Bouncing(true);
            Debug.Log("0");
        }
        else if (randomIndex == 1)
        {
            CallsScript.Instance.AssignedWindow(randomIndex);
            CallsScript.Instance.Bouncing(true);
            Debug.Log("1");
        }
        else if (randomIndex == 2)
        {
            CallsScript.Instance.AssignedWindow(randomIndex);
            CallsScript.Instance.Bouncing(true);
            Debug.Log("2");
        }
        else if (randomIndex == 3)
        {
            CallsScript.Instance.AssignedWindow(randomIndex);
            CallsScript.Instance.Bouncing(true);
            Debug.Log("3");
        }
        else if (randomIndex == 4)
        {
            CallsScript.Instance.AssignedWindow(randomIndex);
            CallsScript.Instance.Bouncing(true);
            Debug.Log("4");
        }
        else if (randomIndex == 5)
        {
            CallsScript.Instance.AssignedWindow(randomIndex);
            CallsScript.Instance.Bouncing(true);
            Debug.Log("5");
        }
        else if (randomIndex == 6)
        {
            CallsScript.Instance.AssignedWindow(randomIndex);
            CallsScript.Instance.Bouncing(true);
            Debug.Log("6");
        }
        //GameEvent eventToSpawn = gameEvents[randomIndex];

        // ������� ��������� �������� �������
        //GameObject eventInstance = Instantiate(eventToSpawn.eventPrefab, transform.position, transform.rotation);

        // ���������, �������� �� ������� �������� � �����������, ������������ �����
        /* EventTextDisplay eventTextDisplay = eventInstance.GetComponent<EventTextDisplay>();
         if (eventTextDisplay != null)
         {
             // �������� ��������� �������� ������� �� �������
             string randomDescription = eventToSpawn.eventDescriptions[Random.Range(0, eventToSpawn.eventDescriptions.Length)];
             eventTextDisplay.ShowEventText(randomDescription, eventToSpawn.displayDuration);
         }*/
    }
}

/*[System.Serializable]
public class GameEvent
{
    public GameObject eventPrefab; // ������ �������� �������
    public string[] eventDescriptions; // ������ ��������� �������� ��� �������
    public float displayDuration = 2f; // ����������������� ����������� ������
    // �������������� ��������� � ������ �������
    // ...
}

[System.Serializable]
public class AmbulanceEvent : GameEvent
{
    // �������������� ��������� � ������ ��� ������ "������ ������"
    // ...
}

[System.Serializable]
public class FirefightersEvent : GameEvent
{
    // �������������� ��������� � ������ ��� ������ "��������"
    // ...
}

[System.Serializable]
public class PoliceEvent : GameEvent
{
    // �������������� ��������� � ������ ��� ������ "�������"
    // ...
}*/

/*public class EventTextDisplay : MonoBehaviour
{
    public TextMesh eventText; // ������ �� ��������� TextMesh ��� ����������� ������

    private void Start()
    {
        eventText.gameObject.SetActive(false); // ���������� �������� �����
    }

    public void ShowEventText(string text, float duration)
    {
        eventText.text = text; // ������������� �����, ������� ����� ����������
        eventText.gameObject.SetActive(true); // ���������� �����

        // ��������� ��������, ����� ������ ����� ����� �������� �����������������
        StartCoroutine(HideEventTextCoroutine(duration));
    }

    private IEnumerator HideEventTextCoroutine(float duration)
    {
        yield return new WaitForSeconds(duration);
        eventText.gameObject.SetActive(false); // �������� �����
    }
}*/
