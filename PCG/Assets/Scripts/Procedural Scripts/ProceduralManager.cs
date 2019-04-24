using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Procedural Manager Class - determines Procedural Content Generation
public class ProceduralManager : MonoBehaviour
{
    [Header("Parent"), Tooltip("The 'Folder' gameobject to store all 'Building Folders'.")]
    public Transform buildingParent;
    
    [Header("Buildings PCG"), Range(1, 50)]
    public int buildingsMaxMid = 1;
    public List<GameObject> buildingBases, buildingMids, buildingRoofs;

    [HideInInspector]
    public float[] randomYRotation = { 0, 90, 180, 270 };
    private static int buildingNumber = 0;

    [Header("Terrain PCG")]
    public Terrain cityTerrain;
    public float totalTerrainHeight, totalTerrainLength;
    public List<Terrain> terrainList;

    // Set Handles
    void Start()
    {
        // Get Terrain Information
        terrainList.AddRange(FindObjectsOfType<Terrain>());

        for (int i = 0; i < terrainList.Count; i++)
        {
            totalTerrainHeight += terrainList[i].terrainData.size.x;
            totalTerrainLength += terrainList[i].terrainData.size.z;

            if (terrainList[i].tag == "City_Terrain")
                cityTerrain = terrainList[i];
        }

    }

}
