using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float rotationSpeed = 100;
    public float moveSpeed = 10;
    public float jumpForce = 100;
    public Animator anim;
    public Bullet bullet;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            Rotate(-1);
        else if (Input.GetKey(KeyCode.RightArrow))
            Rotate(1);
        if(Input.GetKey(KeyCode.UpArrow))
            MoveForward(1);
        else if (Input.GetKey(KeyCode.DownArrow))
            MoveForward(-1);
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
        if (Input.GetKeyDown(KeyCode.Z))
            Shoot();
    }
    void Rotate(int direction)
    {
        transform.Rotate(Vector3.up * direction * (rotationSpeed * Time.deltaTime));
    }
    void MoveForward(int direction)
    {
        anim.Play("walk");
        transform.Translate(Vector3.forward * direction * (moveSpeed * Time.deltaTime));
    }
    void Jump()
    {
        GetComponent<Rigidbody>().AddForce( Vector3.up * jumpForce );
    }
    void Shoot()
    {
        Bullet newBullet = Instantiate(bullet);
        newBullet.transform.position = transform.position;
        newBullet.transform.rotation = transform.rotation;
        newBullet.OnInit(3);
    }
}
