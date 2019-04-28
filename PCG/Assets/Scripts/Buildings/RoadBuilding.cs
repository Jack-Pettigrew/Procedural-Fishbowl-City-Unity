using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBuilding : MonoBehaviour
{
    // Building Objects
    public GameObject[] buildingBase;
    private ProceduralManager pm;
    private Transform buildingParent;

    private void Awake()
    {
        pm = FindObjectOfType<ProceduralManager>();
        buildingParent = pm.buildingParent;
    }

    void Start()
    {
        GameObject buildingBase = GetRandomBase();

        // Instantiate Building
        Transform buildingTransform = Instantiate(buildingBase, transform.position, transform.rotation, buildingParent).transform;
        buildingTransform.LookAt(new Vector3(transform.position.x, transform.position.y, transform.position.z));

        // Calculate movement axis according to rotation
        Vector3 crossProduct = Vector3.Cross(transform.forward, transform.up);
        float buildingDistance = buildingBase.GetComponent<MeshRenderer>().bounds.size.z;

        // Move building according to size values
        buildingTransform.position += crossProduct * buildingDistance;
        buildingTransform.LookAt(new Vector3(transform.position.x, buildingTransform.position.y, transform.position.z));
        pm.spawnPoints.Add(buildingTransform.GetComponentInChildren<NpcSpawner>().transform);

        // ...Again for second building
        buildingBase = GetRandomBase();
        buildingTransform = Instantiate(buildingBase, transform.position, transform.rotation, buildingParent).transform;
        buildingTransform.LookAt(new Vector3(transform.position.x, transform.position.y, transform.position.z));

        crossProduct = Vector3.Cross(transform.forward, transform.up);
        buildingDistance = buildingBase.GetComponent<MeshRenderer>().bounds.size.z;

        buildingTransform.position += crossProduct * -buildingDistance;
        buildingTransform.LookAt(new Vector3(transform.position.x, buildingTransform.position.y, transform.position.z));
        pm.spawnPoints.Add(buildingTransform.GetComponentInChildren<NpcSpawner>().transform);

    }

    GameObject GetRandomBase()
    {
        int maxBases = pm.buidlingBases.Length;
        GameObject buildingBase = pm.buidlingBases[Random.Range(0, maxBases)];

        return buildingBase;
    }

}
