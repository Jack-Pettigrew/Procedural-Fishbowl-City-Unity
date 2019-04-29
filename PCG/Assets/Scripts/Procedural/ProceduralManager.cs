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

    [Header("Roads")]
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

    [Header("NPCs")]
    public int npcsCount = 0;
    public int maxNpcs = 100;
    public List<GameObject> npcList;
    [HideInInspector]
    public List<Transform> spawnPoints;

    [Header("Environment"), Range(50, 1000)]
    public int numberOfEnvironment = 5;
    public List<GameObject> environmentList;

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