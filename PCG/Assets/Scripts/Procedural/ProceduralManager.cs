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
    private float[] randomYRotation = { 0, 90, 180, 270 };
    private static int buildingNumber = 0;

    [Header("Terrain PCG")]
    public float terrainWidth, terrainLength;
    public Terrain terrain;

    // Set Handles
    void Start()
    {
        // Get Terrain Information
        terrain = FindObjectOfType<Terrain>();
        terrainWidth = terrain.terrainData.size.x;
        terrainLength = terrain.terrainData.size.z;

        // Start PCG Building coroutine
        //StartCoroutine(Build());
    }

    public Transform BuildBuilding(Transform roadPieceTransform)
    {
        // Spawn Holder for Buildings
        GameObject building = Instantiate(buidlingFolderPrefab, buildingHolder.transform) as GameObject;
        building.name = "Building " + buildingNumber++;

        // Index for random sections
        int baseIndex = Random.Range(0, buildingBases.Count);
        int roofIndex = Random.Range(0, buildingRoofs.Count);

        // Sample pos for building
        Vector3 pos = new Vector3(roadPieceTransform.position.x, 0, roadPieceTransform.position.z);
        pos.y += Terrain.activeTerrain.SampleHeight(pos);

        // Spawn Building Base
        GameObject baseBuilding = Instantiate(buildingBases[baseIndex], pos, transform.rotation, building.transform);
        baseBuilding.AddComponent<BoxCollider>();

        /// Account for Y bounds for building Base
        pos.y += buildingBases[baseIndex].GetComponent<MeshRenderer>().bounds.size.y;

        // Spawn Building Mids
        for (int j = 0; j < Random.Range(1, buildingsMaxMid + 1); j++)
        {
            transform.Rotate(Vector3.up, randomYRotation[Random.Range(0, randomYRotation.Length)]);

            int midIndex = Random.Range(0, buildingMids.Count);

            Instantiate(buildingMids[midIndex], pos, transform.rotation, building.transform).AddComponent<BoxCollider>();

            pos.y += buildingMids[midIndex].GetComponent<MeshRenderer>().bounds.size.y;
        }

        // Spawn Building Roof
        Instantiate(buildingRoofs[roofIndex], pos, transform.rotation, building.transform).AddComponent<BoxCollider>();

        return building.transform;
    }

    // Coroutine - Builds the specified number of buildings
    IEnumerator Build()
    {
        // Creates the specified amount of Buildings
        for (int i = 0; i < buildingAmount; i++)
        {
            // Spawn Holder for Buildings
            GameObject building = Instantiate(buidlingFolderPrefab, buildingHolder.transform) as GameObject;
            building.name = "Building " + i;

            // Index for random sections
            int baseIndex = Random.Range(0, buildingBases.Count);
            int roofIndex = Random.Range(0, buildingRoofs.Count);

            // Sample a random pos for building
            Vector3 pos = new Vector3(terrain.transform.position.x + Random.Range(0, terrainWidth), 0, terrain.transform.position.z + Random.Range(0, terrainLength));
            /// Modify Y pos according to Terrain Height
            pos.y += Terrain.activeTerrain.SampleHeight(pos);

            // Spawn Building Base
            Instantiate(buildingBases[baseIndex], pos, transform.rotation, building.transform).AddComponent<BoxCollider>();

            /// Account for Y bounds for building Base
            pos.y += buildingBases[baseIndex].GetComponent<Renderer>().bounds.size.y;

            // Spawn Building Mids
            for (int j = 0; j < Random.Range(1, buildingsMaxMid + 1); j++)
            {
                transform.Rotate(Vector3.up, randomYRotation[Random.Range(0, randomYRotation.Length)]);

                int midIndex = Random.Range(0, buildingMids.Count);

                Instantiate(buildingMids[midIndex], pos, transform.rotation, building.transform).AddComponent<BoxCollider>();

                pos.y += buildingMids[midIndex].GetComponent<Renderer>().bounds.size.y;
            }

            // Spawn Building Roof
            Instantiate(buildingRoofs[roofIndex], pos, transform.rotation, building.transform).AddComponent<BoxCollider>();

            // Delay time
            yield return new WaitForSeconds(0.1f);
        }

        yield return null;
    }

}
