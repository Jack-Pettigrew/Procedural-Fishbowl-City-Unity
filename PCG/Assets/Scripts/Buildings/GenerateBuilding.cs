using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBuilding : MonoBehaviour
{
    private ProceduralManager pm;

    [SerializeField]
    private GameObject[] buildingMids, buildingRoofs;

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

        float height = GetComponentInParent<MeshRenderer>().bounds.size.y;
        int roofIndex = Random.Range(0, buildingRoofs.Length);

        spawnPosition.y += height;

        for (int i = 0; i < Random.Range(1, pm.buildingsMaxMid); i++)
        {
            int midIndex = Random.Range(0, buildingMids.Length);

            Transform currentMid = Instantiate(buildingMids[midIndex], spawnPosition, transform.rotation).transform;
            currentMid.SetParent(this.transform);

            currentMid.Rotate(Vector3.up, pm.randomYRotation[Random.Range(0, pm.randomYRotation.Length)]);

            spawnPosition.y += buildingMids[midIndex].GetComponent<Renderer>().bounds.size.y;
        }

        Instantiate(buildingRoofs[roofIndex], spawnPosition, transform.rotation).transform.SetParent(this.transform);
    }
}
