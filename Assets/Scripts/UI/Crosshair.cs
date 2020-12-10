using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    private RectTransform reticle;

    public float minSize;
    public float maxSize;
    public float maxSpeed;
    public float minSpeed;
    private float currentSize;


    private void Start()
    {
        reticle = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if(isAttack)
        {
            currentSize = Mathf.Lerp(currentSize, maxSize, Time.deltaTime * maxSpeed);
        }
        else
        {
            currentSize = Mathf.Lerp(currentSize, minSize, Time.deltaTime * minSpeed);
        }

        reticle.sizeDelta = new Vector2(currentSize, currentSize);
    }

    bool isAttack
    {
        get
        {
            if(Input.GetButton("Fire1"))
            {
                return true;
            }
            else
                return false;
        }
    }
}
