using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] public PlayerMissile playerMissile_prefab;
    private List<PlayerMissile> playerMissilePool = new List<PlayerMissile>();
    private readonly int missileMaxCount = 10;
    public int currMissileIndex = 0;

    [SerializeField] public EnemyBullet enemyBullet_prefab;
    private List<EnemyBullet> enemyBulletPool = new List<EnemyBullet>();
    private readonly int enemyBulletMaxCount = 80;
    public int currEnemyBulletIndex = 0;

    [SerializeField] public EnemyController enemy_prefab_1;
    public List<EnemyController> enemyPool_1 = new List<EnemyController>();
    private readonly int enemyMaxCount_1 = 30;
    public int currEnemyIndex = 0;
    private void Awake()
    {
       
    }
    void Start()
    {
        for (int i = 0; i < missileMaxCount; ++i)
        {
            PlayerMissile pb = Instantiate<PlayerMissile>(playerMissile_prefab);
            pb.gameObject.SetActive(false);
            playerMissilePool.Add(pb);
        }

        for(int i = 0; i< enemyBulletMaxCount; ++i)
        {
            EnemyBullet eb = Instantiate<EnemyBullet>(enemyBullet_prefab);
            eb.gameObject.SetActive(false);
            enemyBulletPool.Add(eb);
        }

        for (int i = 0; i < enemyMaxCount_1; ++i)
        {
            EnemyController ec = Instantiate<EnemyController>(enemy_prefab_1);
            ec.gameObject.SetActive(false);
            enemyPool_1.Add(ec);
        }
    }

    public void PlayerMissileCreate(int index, Transform firePos)
    {
        currMissileIndex = index;
        playerMissilePool[currMissileIndex].transform.position = firePos.position;
        playerMissilePool[currMissileIndex].transform.rotation = firePos.rotation;
        playerMissilePool[currMissileIndex].gameObject.SetActive(true);
    }

    public int GetPlayerBulletMaxCount()
    {
        return missileMaxCount;
    }

    public void EnemyBulletCreate(int index, Transform firePos)
    {
        currEnemyBulletIndex = index;
        enemyBulletPool[currEnemyBulletIndex].transform.position = firePos.position;
        enemyBulletPool[currEnemyBulletIndex].transform.rotation = firePos.rotation;
        enemyBulletPool[currEnemyBulletIndex].gameObject.SetActive(true);
    }

    public int GetEnemyBulletMaxCount()
    {
        return enemyBulletMaxCount;
    }

    public void EnemyCreate(Transform spawnPos)
    {
        for(int i = 0; i< enemyMaxCount_1; ++i)
        {
            if(enemyPool_1[i].gameObject.activeSelf == false)
            {
                enemyPool_1[i].transform.position = spawnPos.position;
                enemyPool_1[i].transform.rotation = spawnPos.rotation;
                currEnemyIndex = i;
                enemyPool_1[i].Init();
                enemyPool_1[i].gameObject.SetActive(true);
                break;
            }
        }
    }

    public int GetEnemyMaxCount()
    {
        return enemyBulletMaxCount;
    }


    void Update()
    {
        
    }
}
