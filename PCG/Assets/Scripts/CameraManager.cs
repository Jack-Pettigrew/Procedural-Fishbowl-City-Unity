using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [Header("Camera Properties")]
    public float mouseSensitivity = 1.0f;
    public float cameraDistance = 10.0f;
    public Transform lookAtTarget;
    public Transform van;

    private float mouseX, mouseY;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        mouseX += Input.GetAxis("Mouse X") * mouseSensitivity;
        mouseY += Input.GetAxis("Mouse Y") * mouseSensitivity;

        mouseY = Mathf.Clamp(mouseY, -90, 90);
    }

    // Wait for Update movements
    void LateUpdate()
    {
        // Get distance + Rotation via mouse
        Vector3 distance = new Vector3(0, 0, -cameraDistance);
        Quaternion rotation = Quaternion.Euler(-mouseY, mouseX, 0);

        // Set position to Van + mouse rotation * desired camera distance
        transform.position = van.position + rotation * distance;

        // Look at Van Pos
        transform.LookAt(lookAtTarget);
    }
}
