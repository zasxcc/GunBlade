using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private Vector3 direction;
    private Transform tr;
    private float speed = 100.0f;

    private void Awake()
    {
        
    }

    private void Start()
    {
        tr = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        tr.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
    }
    
}
