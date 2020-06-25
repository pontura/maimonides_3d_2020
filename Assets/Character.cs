using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float rotationSpeed = 100;
    public float moveSpeed = 10;
    public float jumpForce = 100;
    public Animator anim;
    public Transform handTransform;

    public actionStates actionState;
    public enum actionStates
    {
        IDLE,
        JUMP,
        WALK,
        RESET_JUMP,
        DEAD
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

        if (Input.GetKeyDown(KeyCode.A))
            TryToGrabOrLeft();
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
            anim.Play("Idle");
            actionState = actionStates.IDLE;
        }
    }
    void Jump()
    {
        if (actionState != actionStates.JUMP && actionState != actionStates.DEAD)
        {
            anim.Play("attack");
            actionState = actionStates.JUMP;
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
        }
    }
    void ResetJump()
    {
        actionState = actionStates.RESET_JUMP;
        Idle();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            if (actionState == actionStates.JUMP)
                ResetJump();
        }
    }

    public GrabbableBox grabbableGameObject;
    public GrabbableBox objectGrabbed;

    private void OnTriggerEnter(Collider collider)
    {
        grabbableGameObject = collider.GetComponent<GrabbableBox>();
    }
    private void OnTriggerExit(Collider collider)
    {
        grabbableGameObject = null;
    }
    void TryToGrabOrLeft()
    {
        if (grabbableGameObject != null)
        {
            print("Grab: " + grabbableGameObject.name);
            objectGrabbed = grabbableGameObject;
            grabbableGameObject.OnGrab();
            grabbableGameObject.transform.SetParent(handTransform);
            grabbableGameObject.transform.localPosition = Vector3.zero;
            grabbableGameObject = null;
        }
        else if(objectGrabbed != null)
        {
            print("Left: " + objectGrabbed.name);
            objectGrabbed.OnLeft();
            objectGrabbed.transform.SetParent(transform.parent);
            objectGrabbed = null;
        } else
            print("no hay nada para agarrar o dejar");
    }
}
