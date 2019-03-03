using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Procedural Manager Class - determines Procedural Content Generation
public class ProceduralManager : MonoBehaviour
{
    [Header("Buildings PCG"), Range(1, 200)]
    public int buildingAmount = 1;
    [Range(1, 50)]
    public int buildingsMaxMid = 1;
    public List<GameObject> buildingBases, buildingMids, buildingRoofs;

    public float terrainWidth, terrainLength;
    private Terrain terrain;

    // Set Script specific elements
    void Awake()
    {
        
    }

    // Set Handles
    void Start()
    {
        // Get Terrain dimensions
        terrain = FindObjectOfType<Terrain>();
        terrainWidth = terrain.terrainData.size.x;
        terrainLength = terrain.terrainData.size.z;

        // Start Coroutine
        StartCoroutine(Build());
    }

    // Coroutine bulding PCG elements
    IEnumerator Build()
    {
        Quaternion blenderRotationOffest = Quaternion.Euler(-90.0f, 0.0f, 0.0f);

        // Creates the specified amount of Buildings
        for (int i = 0; i < buildingAmount; i++)
        {
            // Index for random sections
            int index = Random.Range(0, buildingBases.Count);

            // Pos of each building
            Vector3 pos = new Vector3(terrain.transform.position.x + Random.Range(0, terrainWidth), 0, terrain.transform.position.z + Random.Range(0, terrainLength));
            pos.y += Terrain.activeTerrain.SampleHeight(pos);

            // Spawn
            Instantiate(buildingBases[index], pos, blenderRotationOffest);

            pos.y += buildingBases[index].GetComponent<Renderer>().bounds.size.y;

            for (int j = 0; j < Random.Range(1, buildingsMaxMid + 1); j++)
            { 
                Instantiate(buildingMids[index], pos, blenderRotationOffest);

                pos.y += buildingMids[index].GetComponent<Renderer>().bounds.size.y;
            }

            Instantiate(buildingRoofs[index], pos, blenderRotationOffest);

            yield return new WaitForSeconds(0.1f);
        }

        yield return null;
    }

}
