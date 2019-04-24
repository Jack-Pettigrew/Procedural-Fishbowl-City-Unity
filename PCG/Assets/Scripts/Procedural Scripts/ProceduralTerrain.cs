using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralTerrain : MonoBehaviour
{

    // Procedural Terrain
    private ProceduralManager pm;

    void Start()
    {
        pm = FindObjectOfType<ProceduralManager>();
    }
}
