using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadPieceLogic : MonoBehaviour
{

    private void OnCollisionStay(Collision other)
    {
        if(other.gameObject.name == "Road F")
        {
            transform.Translate(Vector3.forward * this.GetComponent<MeshRenderer>().bounds.size.y);
        }
    }

}
