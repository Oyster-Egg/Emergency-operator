using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    public Transform follow_transform;
    public Transform camera_transform;

    public float normal_speed;
    public float fast_speed;
    public float movement_speed;
    public float movement_time;
    public float rotation_amount;
    public Vector3 zoom_amount;

    public Vector3 camZoom;
    public Vector3 newZoom;
    public Vector3 newPosition;
    public Quaternion newRotation;

    public Vector3 dragStartPosition;
    public Vector3 dragCurrentPosition;
    public Vector3 rotateStartPosition;
    public Vector3 rotateCurrentPosition;

    // The target we are following
    public Transform target;

    // The smooth speed of the camera
    public float smoothSpeed = 10f;

    // The offset of the camera from the target
    private Vector3 offset = new Vector3(0, 3000, -1700);


    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        newPosition = transform.position;
        newRotation = transform.rotation;
        newZoom = camera_transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (follow_transform != null)
        {
            // Create a ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Declare a variable to store the hit information
            RaycastHit hit;

            // Check if the ray hits any collider in the scene
            if (Physics.Raycast(ray, out hit))
            {
                // Check if the collider belongs to a character (you can use tags or layers for this)
                if (hit.collider.CompareTag("Car"))
                {
                    // Assign the collider's transform to the target variable
                    target = hit.transform;
                }
            }
        }
        else
        {
            HandleMouseInput();
            HandleMovementInput();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            follow_transform = null;
            target = null;
            camera_transform.localPosition = Vector3.Lerp(camera_transform.localPosition, camZoom, Time.deltaTime * movement_speed);
        }

        // If we have a target
        if (target != null)
        {

            // Set the position of the camera
            camZoom = camera_transform.localPosition;
            transform.position = target.position;
            camera_transform.localPosition = Vector3.Lerp(camera_transform.localPosition, offset, Time.deltaTime * smoothSpeed);

            // Make the camera look at the target
            transform.LookAt(target);
        }
        }

    
       /* // Check if the left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Create a ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Declare a variable to store the hit information
            RaycastHit hit;

            // Check if the ray hits any collider in the scene
            if (Physics.Raycast(ray, out hit))
            {
                // Check if the collider belongs to a character (you can use tags or layers for this)
                if (hit.collider.CompareTag("Car"))
                {
                    // Assign the collider's transform to the target variable
                    target = hit.transform;
                }
            }
        }

        // If we have a target
        if (target != null)
        {

            // Set the position of the camera
            camZoom = camera_transform.localPosition;
            transform.position = target.position;
            camera_transform.localPosition = Vector3.Lerp(camera_transform.localPosition, offset, Time.deltaTime * smoothSpeed);

            // Make the camera look at the target
            transform.LookAt(target);
        }
        else
        {
            HandleMouseInput();
            HandleMovementInput();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            target = null;
            camera_transform.localPosition = Vector3.Lerp(camera_transform.localPosition,camZoom,Time.deltaTime * movement_speed);
           
        }
    }*/

    void HandleMouseInput()
    { 
        if (Input.mouseScrollDelta.y != 0)
        {
            newZoom += Input.mouseScrollDelta.y * zoom_amount*15f;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Plane plane = new Plane(Vector3.up,Vector3.zero);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float entry;

            if (plane.Raycast(ray, out entry))
            {
                dragStartPosition = ray.GetPoint(entry);
            }
        }

        if (Input.GetMouseButton(0)) 
        {
            Plane plane = new Plane(Vector3.up, Vector3.zero);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float entry;

            if (plane.Raycast(ray, out entry))
            {
                dragCurrentPosition = ray.GetPoint(entry);

                newPosition = transform.position + dragStartPosition - dragCurrentPosition;
            }
        }
        if (Input.GetMouseButtonDown(1)) 
        { 
            rotateStartPosition = Input.mousePosition;
        }
        if (Input.GetMouseButton(1)) 
        { 
            rotateCurrentPosition = Input.mousePosition;

            Vector3 difference = rotateStartPosition - rotateCurrentPosition;

            rotateStartPosition = rotateCurrentPosition;

            newRotation *= Quaternion.Euler(Vector3.up * (-difference.x / 5f));
        }
    }

    void HandleMovementInput()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movement_speed = fast_speed;
        }

        else
        {
            movement_speed = normal_speed;
        }

        if (Input.GetKey(KeyCode.W)||  Input.GetKey(KeyCode.UpArrow)) 
        {
            newPosition += (transform.forward * movement_speed);
        }

        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            newPosition += (transform.forward * -movement_speed);
        }

        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            newPosition += (transform.right * movement_speed);
        }

        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            newPosition += (transform.right * -movement_speed);
        }

        if(Input.GetKey(KeyCode.Q))
        {
            newRotation *= Quaternion.Euler(Vector3.up * rotation_amount);
        }

        if (Input.GetKey(KeyCode.E))
        {
            newRotation *= Quaternion.Euler(Vector3.up * -rotation_amount);
        }

        if (Input.GetKey(KeyCode.R))
        {
            newZoom += zoom_amount;
        }

        if (Input.GetKey(KeyCode.F))
        {
            newZoom -= zoom_amount;
        }

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movement_time);

        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * movement_time);

        camera_transform.localPosition = Vector3.Lerp(camera_transform.localPosition, newZoom, Time.deltaTime * movement_time);

    }
}
