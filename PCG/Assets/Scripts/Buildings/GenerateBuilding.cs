using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBuilding : MonoBehaviour
{
    // Handles to building sections
    // PCG Variables
    // Move Build Code here

    void Start()
    {
        
    }

//    // Spawn Holder for Buildings
//    GameObject building = Instantiate(buidlingFolderPrefab, buildingHolder.transform) as GameObject;
//    building.name = "Building " + i;

//            // Index for random sections
//            int baseIndex = Random.Range(0, buildingBases.Count);
//    int roofIndex = Random.Range(0, buildingRoofs.Count);

//    // Sample a random pos for building
//    Vector3 pos = new Vector3(terrain.transform.position.x + Random.Range(0, terrainWidth), 0, terrain.transform.position.z + Random.Range(0, terrainLength));
//    /// Modify Y pos according to Terrain Height
//    pos.y += Terrain.activeTerrain.SampleHeight(pos);

//            // Spawn Building Base
//            Instantiate(buildingBases[baseIndex], pos, transform.rotation, building.transform).AddComponent<BoxCollider>();

//            /// Account for Y bounds for building Base
//            pos.y += buildingBases[baseIndex].GetComponent<Renderer>().bounds.size.y;

//            // Spawn Building Mids
//            for (int j = 0; j<Random.Range(1, buildingsMaxMid + 1); j++)
//            {
//                transform.Rotate(Vector3.up, randomYRotation[Random.Range(0, randomYRotation.Length)]);

//                int midIndex = Random.Range(0, buildingMids.Count);

//    Instantiate(buildingMids[midIndex], pos, transform.rotation, building.transform).AddComponent<BoxCollider>();

//                pos.y += buildingMids[midIndex].GetComponent<Renderer>().bounds.size.y;
//            }

//// Spawn Building Roof
//Instantiate(buildingRoofs[roofIndex], pos, transform.rotation, building.transform).AddComponent<BoxCollider>();
}
