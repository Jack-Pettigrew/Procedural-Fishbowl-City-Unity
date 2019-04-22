using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadPieceLogic : MonoBehaviour
{

    private void OnCollisionStay(Collision other)
    {
        if(other.gameObject.tag == "Road")
        {
            transform.Translate(Vector3.forward * this.GetComponent<MeshRenderer>().bounds.size.y);
        }
    }

}
