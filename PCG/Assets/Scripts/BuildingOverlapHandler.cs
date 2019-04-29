using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingOverlapHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.name == "Bank" || col.name == "Library")
        {
            Destroy(col.gameObject);
        }
    }
}
