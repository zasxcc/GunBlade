using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private float currspawnTime = 0;
    public float spawnTime = 0;
    private Transform spawnPos;
    private ObjectPool op;
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        spawnPos = GetComponent<Transform>();
        op = GameObject.FindObjectOfType<ObjectPool>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (currspawnTime > spawnTime)
        {
            op.EnemyCreate(spawnPos);
            currspawnTime = 0;
        }

        currspawnTime++;
        if(gm.enemyCount > 10)
        {
            spawnTime = spawnTime * 0.9f;
            gm.enemyCount = 0;
        }
        
    }
}
