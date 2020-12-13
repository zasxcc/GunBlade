﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public float HP = 100.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "EnemyBullet(Clone)")
        {
            HP -= 1.0f;
            other.gameObject.SetActive(false);
        }
    }
}
