using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PoliceLight : MonoBehaviour
{
    // The interval between each blink in seconds
    public float blinkInterval = 0.5f;

    // The offset for alternating blinks
    public float offset = 0f;

    // The current state of the light (on or off)
    private bool lightState = true;

    // Update is called once per frame
    void Update()
    {
        // Get the current time in seconds
        float currentTime = Time.time;

        // Add the offset to the timer
        currentTime += offset;

        // Get the number of blinks that have occurred so far
        int blinkCount = Mathf.FloorToInt(currentTime / blinkInterval);

        // Toggle the light state every blink interval
        if (blinkCount % 2 == 0)
        {
            lightState = true;
        }
        else
        {
            lightState = false;
        }

        // Set the light component's enabled property based on the light state
        GetComponent<Light>().enabled = lightState;
    }
}