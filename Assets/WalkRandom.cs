﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkRandom : MonoBehaviour
{
    public float moveSpeed = 10;

    private void Start()
    {
        Loop();
    }
    void Loop()
    {
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + Random.Range(-15, 15), 0);
        Invoke("Loop", 0.15f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
            transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + Random.Range(100, 220), 0);
        //anim.Play("idle");
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * (moveSpeed * Time.deltaTime));
    }
}
