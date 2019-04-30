using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider), typeof(Rigidbody))]
public class BuildingOverlapHandler : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<BoxCollider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Bank(Clone)" || other.name == "Library(Clone)")
        {
            Destroy(gameObject);
        }

        if(this.transform.name == "Shop_Base(Clone)" && other.name == "PCG_Base(Clone)")
            Destroy(gameObject);

        if(this.transform.name == other.name)
        {
            int result = Random.Range(0, 1);
            if (result == 0)
                Destroy(gameObject);
            if (result == 1)
                Destroy(other.gameObject);
        }
    }
}
