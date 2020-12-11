using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMissile : MonoBehaviour
{
    private Transform tr;
    private float speed = 100.0f;
    private ObjectPool op;

    void Start()
    {
        tr = GetComponent<Transform>();
        op = GameObject.FindObjectOfType<ObjectPool>();
    }

    // Update is called once per frame
    void Update()
    {
        tr.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.LogError("EEEE");
    }
}
