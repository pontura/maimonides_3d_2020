using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Walls : MonoBehaviour
{
    public Wall[] all;
    public Image progressBarImage;
    float value = 0;
    public float totalTime = 10;

    private void Start()
    {
        all = GetComponentsInChildren<Wall>();
    }
    private void Update()
    {
        value += Time.deltaTime;
        progressBarImage.fillAmount = value / totalTime;
        
        if (value > totalTime)
            value = 0;
    }
    public void ActiveColor(Color color)
    {
        foreach (Wall wall in all)
        {
            if(wall.color == color)
            {
                wall.Switch();
            }
        }
    }

}
