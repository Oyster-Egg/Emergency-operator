using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

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

    public float interval = 0.05f;
    public int times = 25;
    public bool bounce;
    public static CallsScript Instance;
    public GameObject imaga;
    public int type;

    private void Awake()
    {
        Instance = this;
        ResumeGameAction = new UnityAction(SendCar);
        CancelAction = new UnityAction(Help);
        AlternateAction = new UnityAction(Decline);
    }

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
        Bouncing(bounce);
    }
    public void Confirm()
    {
        bounce = false;
        Time.timeScale = 0;
        UIController.Instance.modalWindow.DialogWindow("Входящий вызов:", text, "Отправить машину", "Первая помощь", "Положить трубку", ResumeGameAction, CancelAction, AlternateAction);
    }
    public void Bouncing(bool bounce)
    {
        if (bounce == true)
        {   
            StartCoroutine(Blink());
            Debug.Log("Пук пук");
        }
    }
    IEnumerator Blink()
    {
        for (int i = 0; i < times; i++) // Repeat for the number of times
        {
            if (imaga.activeSelf != false)
            {
                imaga.SetActive(false);
            }
            else { 
                imaga.SetActive(true);
            }// Toggle the visibility
            yield return new WaitForSeconds(interval); // Wait for the interval
        }
        imaga.SetActive( true); // Make sure the image is visible at the end
    }
    public void AssignedWindow( int typeE )
    {
        type = typeE;
        if (type == 0)
        {
            int index = UnityEngine.Random.Range(0, Astrings.Length);
            text = Astrings[index];
        }
        else if (type == 1)
        {
            int index = UnityEngine.Random.Range(0, Fstrings.Length);
            text = Fstrings[index]; ;
        }
        else if (type == 2)
        {
            int index = UnityEngine.Random.Range(0, Gstrings.Length);
            text = Gstrings[index]; ;
        }
        else if (type == 3)
        {
            int index = UnityEngine.Random.Range(0, Pbstrings.Length);
            text = Pbstrings[index]; ;
        }
        else if (type == 4)
        {
            int index = UnityEngine.Random.Range(0, Psstrings.Length);
            text = Psstrings[index]; ;
        }
        else if (type == 5)
        {
            int index = UnityEngine.Random.Range(0, Hstrings.Length);
            text = Hstrings[index]; ;
        }
        else if (type == 6)
        {
            int index = UnityEngine.Random.Range(0, Nullstrings.Length);
            text = Nullstrings[index]; ;
        }
    }
    public void SendCar()
    {
        if (type == 0)
        {
            GameObject.FindGameObjectWithTag("Ambulance").GetComponent<Patrol>().ChangeDestination();
            Time.timeScale = 1;
        }
        else if (type == 1)
        {
            GameObject.FindGameObjectWithTag("Firetruck").GetComponent<Patrol>().ChangeDestination();
            Time.timeScale = 1;
        }
        else if (type == 2)
        {
            GameObject.FindGameObjectWithTag("GasService").GetComponent<Patrol>().ChangeDestination();
            Time.timeScale = 1;
        }
        else if(type == 3) 
        {
            GameObject.FindGameObjectWithTag("PoliceBig").GetComponent<Patrol>().ChangeDestination();
            Time.timeScale = 1;
        }
        else if( type == 4)
        {
            GameObject.FindGameObjectWithTag("PoliceSmall").GetComponent<Patrol>().ChangeDestination();
            Time.timeScale = 1;
        }
        else if(type == 5)
        {
            Time.timeScale = 1;
        }
        else if ( type == 6)
        {
            Time.timeScale = 1;
        }
    }
    public void Decline()
    {
        if (type == 0)
        {
           
            Time.timeScale = 1;
        }
        else if (type == 1)
        {
          
            Time.timeScale = 1;
        }
        else if (type == 2)
        {
            
            Time.timeScale = 1;
        }
        else if (type == 3)
        {
         
            Time.timeScale = 1;
        }
        else if (type == 4)
        {
            
            Time.timeScale = 1;
        }
        else if (type == 5)
        {
            Time.timeScale = 1;
        }
        else if (type == 6)
        {
            Time.timeScale = 1;
        }
    }
    public void Help()
    {
        if (type == 0)
        {

            Time.timeScale = 1;
        }
        else if (type == 1)
        {

            Time.timeScale = 1;
        }
        else if (type == 2)
        {

            Time.timeScale = 1;
        }
        else if (type == 3)
        {

            Time.timeScale = 1;
        }
        else if (type == 4)
        {

            Time.timeScale = 1;
        }
        else if (type == 5)
        {
            Time.timeScale = 1;
        }
        else if (type == 6)
        {
            Time.timeScale = 1;
        }
    }

}
