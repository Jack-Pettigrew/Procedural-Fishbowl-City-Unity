using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBuilding : MonoBehaviour
{
    // Building Objects
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

        if (buildingTransform.childCount > 2)
            pm.spawnPoints.Add(buildingTransform.GetComponentInChildren<NpcSpawner>().transform);

        // ...Again for second building
        buildingBase = GetRandomBase();
        buildingTransform = Instantiate(buildingBase, transform.position, transform.rotation, buildingParent).transform;
        buildingTransform.LookAt(new Vector3(transform.position.x, transform.position.y, transform.position.z));

        crossProduct = Vector3.Cross(transform.forward, transform.up);
        buildingDistance = buildingBase.GetComponent<MeshRenderer>().bounds.size.z;

        buildingTransform.position += crossProduct * -buildingDistance;
        buildingTransform.LookAt(new Vector3(transform.position.x, buildingTransform.position.y, transform.position.z));

        if (buildingTransform.childCount > 2)
            pm.spawnPoints.Add(buildingTransform.GetComponentInChildren<NpcSpawner>().transform);

    }

    GameObject GetRandomBase()
    {
        int maxBases = pm.buidlingBases.Length;
        GameObject buildingBase = pm.buidlingBases[Random.Range(0, maxBases)];

        switch(buildingBase.name)
        {
            case "Bank":
                if (Random.Range(0, 19) == 0 && pm.currentNumberBanks < pm.maxNumberBanks)
                {
                    pm.currentNumberBanks++;
                }
                else
                {
                    while (buildingBase.name == "Bank" || buildingBase.name == "Library")
                    {
                        buildingBase = pm.buidlingBases[Random.Range(0, maxBases)];
                    }
                }
                break;

            case "Library":
                if (Random.Range(0, 19) == 0 && pm.currentNumberLibraries < pm.maxNumberLibaries)
                {
                    pm.currentNumberLibraries++;
                }
                else
                {
                    while (buildingBase.name == "Library" || buildingBase.name == "Bank")
                    {
                        buildingBase = pm.buidlingBases[Random.Range(0, maxBases)];
                    }
                }
                break;
        }

        return buildingBase;
    }

}
