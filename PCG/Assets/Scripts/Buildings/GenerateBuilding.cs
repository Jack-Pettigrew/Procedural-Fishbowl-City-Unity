using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBuilding : MonoBehaviour
{
    private ProceduralManager pm;

    private void Awake()
    {
        pm = FindObjectOfType<ProceduralManager>();
    }

    void Start()
    {
        GenerateBuidling();
    }

    // Builds Building from Mid + Roof sections onto base
    void GenerateBuidling()
    {
        Vector3 spawnPosition = transform.position;

        int baseIndex = Random.Range(0, pm.buildingBases.Count);
        int roofIndex = Random.Range(0, pm.buildingRoofs.Count);

        spawnPosition.y += pm.buildingBases[baseIndex].GetComponent<Renderer>().bounds.size.y;

        for (int i = 0; i < Random.Range(1, pm.buildingsMaxMid); i++)
        {
            int midIndex = Random.Range(0, pm.buildingMids.Count);

            Transform currentMid = Instantiate(pm.buildingMids[midIndex], spawnPosition, transform.rotation).transform;
            currentMid.SetParent(this.transform);

            currentMid.Rotate(Vector3.up, pm.randomYRotation[Random.Range(0, pm.randomYRotation.Length)]);

            spawnPosition.y += pm.buildingMids[midIndex].GetComponent<Renderer>().bounds.size.y;
        }

        Instantiate(pm.buildingRoofs[roofIndex], spawnPosition, transform.rotation).transform.SetParent(this.transform);
    }
}
