using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuidlingAssetManager : MonoBehaviour
{
    public GameObject window;

    private Transform[] windowTransforms;

    // Start is called before the first frame update
    void Start()
    {
        windowTransforms = transform.GetComponentsInChildren<Transform>();

        foreach(Transform item in windowTransforms)
        {
            int isSpawned = Random.Range(0, 2);

            switch(isSpawned)
            {
                case 0:
                    break;

                case 1:
                    Instantiate(window, item.position, item.rotation);

                    break;
            }
        }
    }
}
