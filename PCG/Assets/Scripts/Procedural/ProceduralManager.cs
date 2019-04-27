using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Procedural Manager Class - determines Procedural Content Generation
public class ProceduralManager : MonoBehaviour
{
    [Header("Parents"), Tooltip("The 'Folder' gameobject to store all 'Building Folders'.")]
    public Transform buildingParent;
    public bool disableAllPCG;

    [Header("Road PCG")]
    private NavMeshSurface surface;

    [Header("Buildings PCG"), Range(1, 50)]
    public int buildingsMaxMid = 1;
    public GameObject[] buidlingBases;

    [Header("NPCs")]
    public List<GameObject> npcList;

    [HideInInspector]
    public float[] randomYRotation = { 0, 90, 180, 270 };
    private static int buildingNumber = 0;

    [Header("Terrain PCG")]
    public float terrainWidth;
    public float terrainLength;


    public void BakeRoadNavMesh()
    {
        surface = GetComponent<NavMeshSurface>();

        surface.BuildNavMesh();
        
    }

}