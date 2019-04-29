using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSpawner : MonoBehaviour
{
    private ProceduralManager pm;

    private void Awake()
    {
        pm = FindObjectOfType<ProceduralManager>();
    }

    private void FixedUpdate()
    {
        if (pm.npcsCount >= pm.maxNpcs)
            return;

        SpawnNPC();
    }

    private void SpawnNPC()
    {
        Transform spawnPoint = null;

        while(!spawnPoint)
        {
            spawnPoint = pm.spawnPoints[Random.Range(0, pm.spawnPoints.Count)];
        }

        GameObject npc = pm.npcList[Random.Range(0, pm.npcList.Count)];

        Instantiate(npc, spawnPoint.position, Quaternion.identity, pm.npcParent).GetComponent<NPCBehaviour>().pm = pm;

        pm.npcsCount++;
    }
}
