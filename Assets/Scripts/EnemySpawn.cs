using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public int spawnTime;
    private Transform spawnPos;
    private ObjectPool op;

    // Start is called before the first frame update
    void Start()
    {
        spawnPos = GetComponent<Transform>();
        op = GameObject.FindObjectOfType<ObjectPool>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (spawnTime > 100)
        {
            op.EnemyCreate(spawnPos);
            spawnTime = 0;
        }
        
        spawnTime++;
    }
}
