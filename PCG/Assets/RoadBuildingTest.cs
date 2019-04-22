using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBuildingTest : MonoBehaviour
{
    public GameObject buildingBase;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 spawnPos = transform.position;
        spawnPos.x -= (buildingBase.GetComponent<MeshRenderer>().bounds.size.x / 2 + GetComponent<MeshRenderer>().bounds.size.x / 2);

        Transform buildingTransform = Instantiate(buildingBase, spawnPos, transform.rotation).transform;

        buildingTransform.LookAt(new Vector3(transform.position.x, spawnPos.y, transform.position.z));

        spawnPos = transform.position;
        spawnPos.x += (buildingBase.GetComponent<MeshRenderer>().bounds.size.x / 2 + GetComponent<MeshRenderer>().bounds.size.x / 2);

        buildingTransform = Instantiate(buildingBase, spawnPos, transform.rotation).transform;

        buildingTransform.LookAt(new Vector3(transform.position.x, spawnPos.y, transform.position.z));
    }
}
