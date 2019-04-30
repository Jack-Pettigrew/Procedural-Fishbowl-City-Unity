using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityTrafficSpawner : MonoBehaviour
{
    private ProceduralManager pm;
    public GameObject[] ships;
    private List<Transform> poolShips;

    private void Awake()
    {
        pm = FindObjectOfType<ProceduralManager>();
        poolShips = new List<Transform>();
    }

    private void Start()
    {
        Vector3 spawnPos = transform.position;

        for (int x = 0; x < pm.maxTrafficNumber; x++)
        {
            int i = Random.Range(0, ships.Length);
            GameObject ship = Instantiate(ships[i], spawnPos, transform.rotation, transform);

            poolShips.Add(ship.transform);

            spawnPos += transform.forward * Random.Range(7, pm.maxTrafficSpacing);
        }
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < poolShips.Count; i++)
        {
            if ((poolShips[i].position - transform.position).magnitude >= pm.maxTrafficLoopDist)
                poolShips[i].position = transform.position;
        }
    }

}
