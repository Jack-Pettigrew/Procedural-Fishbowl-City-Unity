using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBuilding : MonoBehaviour
{
    // Building Objects
    public GameObject buildingBase;
    private ProceduralManager pm;
    private Transform buildingParent;

    private void Awake()
    {
        pm = FindObjectOfType<ProceduralManager>();
        buildingParent = pm.buildingParent;
    }

    void Start()
    {

        // Instantiate Building
        Transform buildingTransform = Instantiate(buildingBase, transform.position, transform.rotation, buildingParent).transform;
        buildingTransform.LookAt(new Vector3(transform.position.x, transform.position.y, transform.position.z));

        // Calculate movement axis according to rotation
        Vector3 crossProduct = Vector3.Cross(transform.forward, transform.up);
        float buildingDistance = buildingTransform.GetComponent<MeshRenderer>().bounds.size.x;

        // Move building according to size values
        buildingTransform.position += crossProduct * buildingDistance;
        buildingTransform.LookAt(new Vector3(transform.position.x, buildingTransform.position.y, transform.position.z));


        // ...Again for second building
        buildingTransform = Instantiate(buildingBase, transform.position, transform.rotation, buildingParent).transform;
        buildingTransform.LookAt(new Vector3(transform.position.x, transform.position.y, transform.position.z));

        crossProduct = Vector3.Cross(transform.forward, transform.up);
        buildingTransform.position += crossProduct * -buildingDistance;

        buildingTransform.LookAt(new Vector3(transform.position.x, buildingTransform.position.y, transform.position.z));
    }
}
