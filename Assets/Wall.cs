using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public Color color;
    bool isOpen;
    Animation anim;

    private void Start()
    {
        color = GetComponentInChildren<MeshRenderer>().material.color;
        anim = GetComponent<Animation>();
    }
    public void Switch()
    {
        if (!isOpen)
            Open();
        else
            Close();
    }
    public void Open()
    {
        anim.Play("doorOpen");
        isOpen = true;
    }
    public void Close()
    {
        anim.Play("doorClose");
        isOpen = false;
    }
}
