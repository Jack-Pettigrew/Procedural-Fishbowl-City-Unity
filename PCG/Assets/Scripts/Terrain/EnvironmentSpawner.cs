using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentSpawner : MonoBehaviour
{
    private ProceduralManager pm;

    private void Awake()
    {
        pm = FindObjectOfType<ProceduralManager>();
    }

    void Start()
    {
        if(!pm.disableAllPCG)
            StartCoroutine(SpawnEnvironment());
    }

    IEnumerator SpawnEnvironment()
    {
        Terrain terrain = Terrain.activeTerrain;
        float width = terrain.terrainData.size.x;
        float length = terrain.terrainData.size.z;

        for (int i = 0; i < pm.numberOfEnvironment; i++)
        {
            GameObject asset = pm.environmentList[Random.Range(0, pm.environmentList.Count)];

            Vector3 randomPosition = GetRandomTerrainPosition(width, length, terrain);

            asset = Instantiate(asset, randomPosition, Quaternion.identity, pm.environmentParent);
            asset.transform.localScale *= Random.Range(0.5f, 2.0f);
        }

        yield return null;
    }

    private Vector3 GetRandomTerrainPosition(float width, float length, Terrain terrain)
    {
        Vector3 terrainPos = terrain.transform.position;
        Vector3 randomPos;

        randomPos = new Vector3( Random.Range(terrainPos.x, terrainPos.x + width), 0, Random.Range(terrainPos.z, terrainPos.z + length));
        randomPos.y = terrain.SampleHeight(randomPos);

        return randomPos;
    }

    
    
}
