using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableBox : MonoBehaviour
{
    public Rigidbody rb;
    public Collider[] colliders;

    public void OnGrab()
    {
        rb.useGravity = false;
        rb.isKinematic = true;
        foreach (Collider c in colliders)
            c.enabled = false;
    }
    public void OnLeft()
    {
        rb.useGravity = true;
        rb.isKinematic = false;
        foreach (Collider c in colliders)
            c.enabled = true;
    }
}
