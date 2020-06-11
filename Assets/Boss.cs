using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    Transform target;

    public void SomeoneEnteredAlertZone(Transform target)
    {
        // this.target = target;
        GetComponent<Shooter>().Shoot();
    }
    void Update()
    {
        if(target != null)
            transform.LookAt(target);
    }
}
