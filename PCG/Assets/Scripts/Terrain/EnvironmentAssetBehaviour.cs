using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class EnvironmentAssetBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<BoxCollider>().isTrigger = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "City" || other.tag == "Road" || other.tag == "Environment")
        {
            this.transform.position += new Vector3(Random.Range(0, 5), 0, Random.Range(0, 5));
        }
    }

}
