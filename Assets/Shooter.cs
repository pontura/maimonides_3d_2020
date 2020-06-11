using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Bullet bullet;
    public Transform offset;

    public void Shoot()
    {
        Bullet newBullet = Instantiate(bullet);
        newBullet.transform.position = transform.position + offset.transform.localPosition;
        newBullet.transform.rotation = transform.rotation;
        newBullet.OnInit();
    }
}
