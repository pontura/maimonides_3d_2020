using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaAlert : MonoBehaviour
{
    public Boss boss;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Character")
            boss.SomeoneEnteredAlertZone(other.transform);
    }
}
