using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float rotationSpeed = 100;
    public float moveSpeed = 10;
    public float jumpForce = 100;
    public Animator anim;

    public actionStates actionState;
    public enum actionStates
    {
        IDLE,
        JUMP,
        WALK,
        RESET_JUMP
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            MoveForward(1);
        else if (Input.GetKey(KeyCode.DownArrow))
            MoveForward(-1);
        else
            Idle();

        if (Input.GetKey(KeyCode.LeftArrow))
            Rotate(-1);
        else if (Input.GetKey(KeyCode.RightArrow))
            Rotate(1);

        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
        if (Input.GetKeyDown(KeyCode.Z))
            GetComponent<Shooter>().Shoot();
    }
    void Rotate(int direction)
    {
        transform.Rotate(Vector3.up * direction * (rotationSpeed * Time.deltaTime));
    }
    void MoveForward(int direction)
    {
        if (actionState == actionStates.IDLE)
        {
            anim.Play("Walk");
            actionState = actionStates.WALK;
        }
        transform.Translate(Vector3.forward * direction * (moveSpeed * Time.deltaTime));
    }
    void Idle()
    {
        if (actionState != actionStates.JUMP && actionState != actionStates.IDLE)
        {
            anim.Play("idle");
            actionState = actionStates.IDLE;
        }
    }
    void Jump()
    {
        if (actionState != actionStates.JUMP)
        {
            anim.Play("attack");
            Invoke("ResetJump", 2);
            actionState = actionStates.JUMP;
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
        } 
    }
    void ResetJump()
    {
        actionState = actionStates.RESET_JUMP;
    }
    
}
