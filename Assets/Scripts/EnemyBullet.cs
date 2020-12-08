using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Transform tr;
    private float speed = 100.0f;
    private ObjectPool op;
    private int lifeTime = 300;
    private int life = 0;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        op = GameObject.FindObjectOfType<ObjectPool>();
    }

    // Update is called once per frame
    void Update()
    {
        tr.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
        life++;
        if(lifeTime < life)
        {
            this.gameObject.SetActive(false);
            life = 0;
        }
    }
}
