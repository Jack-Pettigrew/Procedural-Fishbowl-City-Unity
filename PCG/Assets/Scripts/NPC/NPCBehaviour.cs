using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCBehaviour : MonoBehaviour
{
    [SerializeField]
    private Material[] materials;
    public SkinnedMeshRenderer mr;

    [HideInInspector]
    public ProceduralManager pm;
    private NavMeshAgent ai;
    private Animator ani;

    private Transform destination;

    public float waitTimer = 0.0f;

    private void Awake()
    {
        ai = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();
    }

    private void Start()
    {
        mr.material = materials[Random.Range(0, materials.Length)];
    }

    void Update()
    {
        ani.SetFloat("speed", ai.velocity.magnitude);

        if (ai.remainingDistance <= 3.0f)
            waitTimer -= Time.deltaTime;

        if (waitTimer <= 0.0f)
            ChooseRandomDestination();
    }

    void ChooseRandomDestination()
    {
        waitTimer = Random.Range(3.0f, 5.0f);

        destination = null;

        while (!destination)
        {
            destination = pm.spawnPoints[Random.Range(0, pm.spawnPoints.Count)];
        }

        ai.SetDestination(destination.position);
    }
}
