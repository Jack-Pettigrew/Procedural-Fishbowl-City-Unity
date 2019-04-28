using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCBehaviour : MonoBehaviour
{
    [HideInInspector]
    public ProceduralManager pm;
    private NavMeshAgent ai;

    private Vector3 destination;

    public float waitTimer = 0.0f;

    private void Awake()
    {
        ai = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
    }

    void Update()
    {
        if (ai.remainingDistance <= 5.0f)
            waitTimer -= Time.deltaTime;

        if (waitTimer <= 0.0f)
            ChooseRandomDestination();
    }

    void ChooseRandomDestination()
    {
        waitTimer = Random.Range(3.0f, 5.0f);

        destination = pm.spawnPoints[Random.Range(0, pm.spawnPoints.Count)].position;

        ai.SetDestination(destination);
    }
}
