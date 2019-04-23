using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBuildingTest : MonoBehaviour
{
    // Procedural Manager Information
    private Transform buildingHolder;
    private GameObject buildingFolderPrefab;
    private int buildingAmount, buildingsMaxMid;
    private List<List<GameObject>> buildingsTypes;

    // Building Objects
    public GameObject buildingBase;
    private ProceduralManager pm;

    private void Awake()
    {
        pm = FindObjectOfType<ProceduralManager>();
    }

    void Start()
    {
        // Instantiate Road
        Transform building = pm.BuildBuilding(this.transform);

        Vector3 crossProduct = Vector3.Cross(transform.forward, transform.up);
        float buildingDistance = GetComponent<MeshRenderer>().bounds.size.x;

        building.position += crossProduct * buildingDistance;



        //// Instantiate Building
        //Transform buildingTransform = Instantiate(buildingBase, transform.position, transform.rotation).transform;
        //buildingTransform.LookAt(new Vector3(transform.position.x, transform.position.y, transform.position.z));

        //Vector3 crossProduct = Vector3.Cross(transform.forward, transform.up);
        //float buildingDistance = buildingTransform.GetComponent<MeshRenderer>().bounds.size.x;

        //buildingTransform.position += crossProduct * buildingDistance;
        //buildingTransform.LookAt(new Vector3(transform.position.x, buildingTransform.position.y, transform.position.z));

        //// Instantiate Building
        //buildingTransform = Instantiate(buildingBase, transform.position, transform.rotation).transform;
        //buildingTransform.LookAt(new Vector3(transform.position.x, transform.position.y, transform.position.z));

        //crossProduct = Vector3.Cross(transform.forward, transform.up);
        //buildingTransform.position += crossProduct * -buildingDistance;

        //buildingTransform.LookAt(new Vector3(transform.position.x, buildingTransform.position.y, transform.position.z));
    }
}
