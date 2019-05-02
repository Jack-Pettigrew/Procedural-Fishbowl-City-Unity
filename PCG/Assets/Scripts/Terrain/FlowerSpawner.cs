using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] flowers;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(flowers[Random.Range(0, flowers.Length)], GetRandomPos(), Quaternion.identity).transform.SetParent(transform);
        }
    }

    private Vector3 GetRandomPos()
    {
        Vector3 pos;

        float distance = 6.0f;

        pos = new Vector3(Random.Range(-distance, distance), 0, Random.Range(-distance, distance));

        pos = transform.position + pos;

        return pos;
    }
}
