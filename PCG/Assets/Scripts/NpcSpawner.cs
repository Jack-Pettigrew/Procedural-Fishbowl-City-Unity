using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSpawner : MonoBehaviour
{

    private ProceduralManager pm;
    public Transform spawnPoint;
    public Transform destination;

    public const float TIMER_START = 5.0f;
    float timer = 0.0f;

    private void Awake()
    {
        timer = TIMER_START;
        pm = FindObjectOfType<ProceduralManager>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0.0f)
            SpawnNPC();
    }

    private void SpawnNPC()
    {
        timer = TIMER_START;

        int npcIndex = Random.Range(0, pm.npcList.Count);

        Instantiate(pm.npcList[npcIndex], spawnPoint.position, Quaternion.identity);
    }
}
