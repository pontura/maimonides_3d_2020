using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 50;

    public void OnInit()
    {
        //transform.position += transform.forward * 3;
        Invoke("Reset", 5);
        GetComponent<Rigidbody>().AddForce(transform.forward * (50 * speed));
    }

    //void Update()
    //{
    //    transform.Translate(Vector3.forward * speed * Time.deltaTime);
    //}
    void Reset()
    {
        Destroy(gameObject);
    }
}
