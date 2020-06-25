using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    public Key key_to_instantiate;

    public Material[] materials;
    public Transform[] posiblePositions;

    public Walls walls;

    void Start()
    {
        int id = 0;
        ShufflePositions();
        foreach(Material material in materials)
        {
            Key key = Instantiate(key_to_instantiate);
           // key.Repositionate();
            key.SetMaterial(material);
            key.transform.SetParent(transform);
            key.transform.position = posiblePositions[id].position;
            key.walls = walls;
            id++;
        }
    }
    void ShufflePositions()
    {
        //mezclar estas posiciones: posiblePositions;
    }
}
