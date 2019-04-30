using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Procedural Manager Class - determines Procedural Content Generation
public class ProceduralManager : MonoBehaviour
{
    [Header("Master PCG")]
    public bool disableAllPCG;

    [Header("Parenting"), Tooltip("The 'Folder' gameobject to store all 'Building Folders'.")]
    public Transform buildingParent;
    public Transform npcParent;
    public Transform environmentParent;

    [Header("City")]
    public bool randomLsystemGeneration;
    private NavMeshSurface surface;

    [Header("Buildings"), Range(1, 50)]
    public int buildingsMaxMid = 1;
    public GameObject[] buidlingBases;
    public int maxNumberBanks = 5;
    public int maxNumberLibaries = 2;
    [HideInInspector]
    public int currentNumberBanks = 0, currentNumberLibraries = 0;

    [HideInInspector]
    public float[] randomYRotation = { 0, 90, 180, 270 };
    private static int buildingNumber = 0;

    [Header("PCG NPCs")]
    public int npcsCount = 0;
    public int maxNpcsPerGeneration = 150;
    public List<GameObject> npcList;
    [HideInInspector]
    public List<Transform> spawnPoints;

    [Header("PCG Environment"), Range(100, 2000)]
    public int numberOfEnvironment = 5;
    public List<GameObject> environmentList;

    [Header("City Traffic")]
    public int maxTrafficNumber = 10;
    public float maxTrafficSpacing = 10.0f;
    public float maxTrafficLoopDist = 10.0f;

    [Header("Skyships")]
    public int maxShipNumber = 10;
    public float maxShipSpacing = 10.0f;
    [Range(250, 1000)]
    public float maxLoopDist = 500.0f;

    public void BakeRoadNavMesh()
    {
        surface = GetComponent<NavMeshSurface>();

        surface.BuildNavMesh();
    }
}