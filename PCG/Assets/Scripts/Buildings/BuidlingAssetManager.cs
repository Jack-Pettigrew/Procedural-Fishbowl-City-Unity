using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuidlingAssetManager : MonoBehaviour
{
    public Transform sign_post;
    private Transform[] windowTransforms;

    public GameObject window, houseSign, chemistSign;


    // Start is called before the first frame update
    void Start()
    {
        int isSpawned;

        windowTransforms = transform.GetComponentsInChildren<Transform>();

        // Window Asset
        foreach (Transform item in windowTransforms)
        {
            if (item.tag != "Window")
                continue;

            isSpawned = Random.Range(0, 2);

            switch(isSpawned)
            {
                case 0:
                    break;

                case 1:
                    Instantiate(window, item.position, item.rotation);

                    break;
            }
        }

        if (sign_post)
        {
            isSpawned = Random.Range(0, 2);

            switch (isSpawned)
            {
                case 0:
                    GameObject SignHouse = Instantiate(houseSign, sign_post.position, sign_post.rotation, sign_post) as GameObject;
                    break;

                case 1:
                    Instantiate(chemistSign, sign_post.position, sign_post.rotation, sign_post);
                    break;
            }
        }
    }
}
