using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    [Header("Car Properties")]
    public float rotationSpeed = 1.0f;
    public float speed = 10.0f;
    public float reverseSpeed = 5.0f;

    private Transform cameraTransform;
    public GameObject leftDoor, rightDoor;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get User Input
        if(Input.GetKey(KeyCode.W))
            rb.AddForce(transform.forward * speed);
        if(Input.GetKey(KeyCode.S))
            rb.AddForce(-transform.forward * reverseSpeed);
        if (Input.GetKey(KeyCode.A))
            rb.AddForce(-transform.right * reverseSpeed);
        if (Input.GetKey(KeyCode.D))
            rb.AddForce(transform.right * reverseSpeed);
        if (Input.GetKey(KeyCode.E))
            rb.AddForce(transform.up * reverseSpeed);
        if (Input.GetKey(KeyCode.Q))
            rb.AddForce(-transform.up * reverseSpeed);


        if (Input.GetKeyDown(KeyCode.F) && leftDoor && rightDoor)
        {
            leftDoor.AddComponent<Rigidbody>();
            rightDoor.AddComponent<Rigidbody>();

            leftDoor.gameObject.transform.parent = null;
            rightDoor.gameObject.transform.parent = null;

        }
    }

    private void LateUpdate()
    {
        //Quaternion rotation = Quaternion.Slerp(transform.rotation, camera.rotation, Time.deltaTime);
        Quaternion rotation = Quaternion.Slerp(transform.rotation, cameraTransform.rotation, Time.deltaTime * rotationSpeed);
        transform.rotation = rotation;

        // Mesh Collision Reset
        rb.angularVelocity = Vector3.zero;
    }
}
