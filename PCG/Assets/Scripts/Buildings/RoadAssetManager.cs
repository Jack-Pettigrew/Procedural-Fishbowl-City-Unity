using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadAssetManager : MonoBehaviour
{
    public GameObject[] assets;
    private Transform[] assetSpawns;

    public int maxAssets = 2;

    void Start()
    {
        assetSpawns = GetComponentsInChildren<Transform>();

        int filledSlots = 0;

        for (int i = 1; i < assetSpawns.Length; i++)
        { 
            if (filledSlots >= maxAssets)
                return;

            if (Random.Range(0, 3) != 0)
                continue;

            filledSlots++;

            GameObject asset = assets[Random.Range(0, assets.Length)];

            Instantiate(asset, assetSpawns[i].position, assetSpawns[i].rotation).transform.SetParent(assetSpawns[i]);
        }
    }

}
