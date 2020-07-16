using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform gotoTransform;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Floor")
            return;

        Vector3 pos = gotoTransform.position;
        pos.z -= 4;
        other.transform.position = pos;
    }
}
