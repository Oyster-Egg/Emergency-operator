using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour
{
    public GameEvent[] gameEvents; // ������ ������ ������� �������
    public float minDelay = 5f; // ����������� �������� ����� ���������� �������
    public float maxDelay = 10f; // ������������ �������� ����� ���������� �������

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
        GameEvent eventToSpawn = gameEvents[randomIndex];

        // ������� ��������� �������� �������
        Instantiate(eventToSpawn.eventPrefab, transform.position, transform.rotation);
    }
}

[System.Serializable]
public class GameEvent
{
    public GameObject eventPrefab; // ������ �������� �������
    // �������������� ��������� � ������ �������
}

[System.Serializable]
public class AmbulanceEvent : GameEvent
{
    
}

