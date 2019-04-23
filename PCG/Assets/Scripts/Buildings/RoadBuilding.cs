using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBuilding : MonoBehaviour
{
    // Building Objects
    public GameObject buildingBase;
    private ProceduralManager pm;

    private void Awake()
    {
        pm = FindObjectOfType<ProceduralManager>();
    }

    void Start()
    {

        // Instantiate Building
        Transform buildingTransform = Instantiate(buildingBase, transform.position, transform.rotation).transform;
        buildingTransform.LookAt(new Vector3(transform.position.x, transform.position.y, transform.position.z));

        Vector3 crossProduct = Vector3.Cross(transform.forward, transform.up);
        float buildingDistance = buildingTransform.GetComponent<MeshRenderer>().bounds.size.x;

        buildingTransform.position += crossProduct * buildingDistance;
        buildingTransform.LookAt(new Vector3(transform.position.x, buildingTransform.position.y, transform.position.z));


        // Instantiate Building
        buildingTransform = Instantiate(buildingBase, transform.position, transform.rotation).transform;
        buildingTransform.LookAt(new Vector3(transform.position.x, transform.position.y, transform.position.z));

        crossProduct = Vector3.Cross(transform.forward, transform.up);
        buildingTransform.position += crossProduct * -buildingDistance;

        buildingTransform.LookAt(new Vector3(transform.position.x, buildingTransform.position.y, transform.position.z));
    }
}
