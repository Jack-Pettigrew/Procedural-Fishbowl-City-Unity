using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBehaviour : MonoBehaviour
{
    public static float speed = 5.0f;

    private void Update()
    {
        transform.localPosition += transform.forward * speed * Time.deltaTime;
    }
}
