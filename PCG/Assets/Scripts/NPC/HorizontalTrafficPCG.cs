using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalTrafficPCG : MonoBehaviour
{

    public void UpdateTrafficPosition(Vector3 size)
    {

        float xPos = size.x / 2;

        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
    }

}
