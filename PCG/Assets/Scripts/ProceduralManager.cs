using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Procedural Manager Class - determines Procedural Content Generation
public class ProceduralManager : MonoBehaviour
{
    [Header("Parent"), Tooltip("The 'Folder' gameobject to store all 'Building Folders'.")]
    public Transform buildingHolder;
    [Tooltip("Prefab 'Folder' for each building, per building.")]
    public GameObject buidlingFolderPrefab;
    
    [Header("Buildings PCG"), Range(1, 200)]
    public int buildingAmount = 1;
    [Range(1, 50)]
    public int buildingsMaxMid = 1;
    public List<GameObject> buildingBases, buildingMids, buildingRoofs;

    [Header("Terrain PCG")]
    public float terrainWidth, terrainLength;
    private Terrain terrain;

    // Set Handles
    void Start()
    {
        // Get Terrain Information
        terrain = FindObjectOfType<Terrain>();
        terrainWidth = terrain.terrainData.size.x;
        terrainLength = terrain.terrainData.size.z;

        // Start PCG Building coroutine
        StartCoroutine(Build());
    }

    // Coroutine - Builds the specified number of buildings
    IEnumerator Build()
    {
        /// Offset for models without rotation applied
        Quaternion blenderRotationOffest = Quaternion.Euler(-90.0f, 0.0f, 0.0f);

        // Creates the specified amount of Buildings
        for (int i = 0; i < buildingAmount; i++)
        {
            // Spawn Holder for Buildings
            GameObject building = Instantiate(buidlingFolderPrefab, buildingHolder.transform) as GameObject;
            building.name = "Building " + i;

            // Index for random sections
            int index = Random.Range(0, buildingBases.Count);

            // Sample a random pos for building
            Vector3 pos = new Vector3(terrain.transform.position.x + Random.Range(0, terrainWidth), 0, terrain.transform.position.z + Random.Range(0, terrainLength));

            // Modify Y pos according to Terrain Height
            pos.y += Terrain.activeTerrain.SampleHeight(pos);

            // Spawn Building Base
            Instantiate(buildingBases[index], pos, blenderRotationOffest, building.transform).AddComponent<BoxCollider>();

            /// Account for Y bounds for building Base
            pos.y += buildingBases[index].GetComponent<Renderer>().bounds.size.y;

            // Spawn Building Mids
            for (int j = 0; j < Random.Range(1, buildingsMaxMid + 1); j++)
            {
                Instantiate(buildingMids[index], pos, blenderRotationOffest, building.transform).AddComponent<BoxCollider>();

                /// Account for Y bounds for building Mid
                pos.y += buildingMids[index].GetComponent<Renderer>().bounds.size.y;
            }

            // Spawn Building Roof
            Instantiate(buildingRoofs[index], pos, blenderRotationOffest, building.transform).AddComponent<BoxCollider>();

            // Delay time
            yield return new WaitForSeconds(0.1f);
        }

        yield return null;
    }

}
