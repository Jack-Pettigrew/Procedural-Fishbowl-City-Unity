using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralSkyTraffic : MonoBehaviour
{
    private ProceduralManager pm;

    public GameObject[] ships;
    public Material[] shipMaterials;

    private List<Transform> poolShips;

    private void Awake()
    {
        pm = FindObjectOfType<ProceduralManager>();
        poolShips = new List<Transform>();
    }

    private void Start()
    {
        Vector3 spawnPos = transform.position;

        for (int x = 0; x < pm.maxShipNumber; x++)
        {
            int i = Random.Range(0, ships.Length);
            GameObject ship = Instantiate(ships[i], spawnPos, transform.rotation, transform);


            ChangeShipColour(ship);

            poolShips.Add(ship.transform);

            spawnPos += transform.forward * Random.Range(7, pm.maxShipSpacing);
        }
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < poolShips.Count; i++)
        {
            if ((poolShips[i].position - transform.position).magnitude >= pm.maxLoopDist)
                poolShips[i].position = transform.position;
        }
    }

    private void ChangeShipColour(GameObject ship)
    {
        int i = Random.Range(0, shipMaterials.Length);

        ship.GetComponent<MeshRenderer>().material = shipMaterials[i];
    }

}
