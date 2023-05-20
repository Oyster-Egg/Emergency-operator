using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public void OnMouseDown()
    {
        CameraController.instance.follow_transform = transform;
    }
}
