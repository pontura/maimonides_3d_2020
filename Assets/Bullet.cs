using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 50;

    public void OnInit(float offsetY)
    {
        transform.position += new Vector3(0, offsetY, 0);
        transform.position += transform.forward * 3;
        Invoke("Reset", 5);
        GetComponent<Rigidbody>().AddForce(transform.forward * 2000);
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
