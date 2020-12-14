using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMissile : MonoBehaviour
{
    public GameObject explosionPrefab;
    private Transform tr;
    private float speed = 100.0f;
    private ObjectPool op;
    private int lifeTime;

    void Start()
    {
        tr = GetComponent<Transform>();
        op = GameObject.FindObjectOfType<ObjectPool>();
        lifeTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        tr.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
        if(lifeTime > 100)
        {
            InitObject();
            gameObject.SetActive(false);
        }
        lifeTime++;
    }

    private void OnTriggerEnter(Collider other)
    {
        SoundManager.instance.PlayExplosionSound();
        GameObject explosion = Instantiate(explosionPrefab, tr.position, Quaternion.FromToRotation(Vector3.up, tr.position));
        Destroy(explosion, 1.0f);

        var target = other.GetComponent<EnemyController>();
        if(target != null)
        {
            target.HP -= 50.0f;
        }

        InitObject();
        gameObject.SetActive(false);
    }

    private void InitObject()
    {
        lifeTime = 0;
    }
}
