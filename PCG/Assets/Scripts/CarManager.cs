using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    [Header("Car Properties")]
    public float rotationSpeed = 1.0f;
    public float speed = 10.0f;

    private Transform cameraTransform;
    public GameObject leftDoor, rightDoor;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.F) && leftDoor && rightDoor)
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
    }
}
