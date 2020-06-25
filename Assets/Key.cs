using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public Walls walls;

    public void SetMaterial(Material material)
    {
        GetComponent<MeshRenderer>().material = material;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Color color = GetComponent<MeshRenderer>().material.color;
        walls.ActiveColor(color);        
    }
    public void Repositionate()
    {
        float _x = Random.Range(-40, 40);
        float _z = Random.Range(-40, 40);
        transform.position = new Vector3(_x, 3, _z);
    }
}
