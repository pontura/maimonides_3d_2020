using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaVision : MonoBehaviour
{
    public Follow follow;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {            
            follow.OnTrigger( other.GetComponent<Character>(), true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            follow.OnTrigger(other.GetComponent<Character>(), false);
        }
    }
}
