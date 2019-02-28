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

    private float terrainWidth, terrainLength;
    private Terrain terrain;

    // Set Script specific elements
    void Awake()
    {
        
    }

    // Set Handles
    void Start()
    {
        terrain = FindObjectOfType<Terrain>();

        terrainWidth = terrain.terrainData.size.x;
        terrainLength = terrain.terrainData.size.z;
    }

    // Coroutine bulding PCG elements
    IEnumerator Build()
    {
        // Creates the specified amount of Buildings
        for (int i = 0; i < buildingAmount; i++)
        {



        }

        yield return null;
    }

}
