using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] public PlayerBullet playerMissile_prefab;
    private List<PlayerBullet> playerMissilePool = new List<PlayerBullet>();
    private readonly int missileMaxCount = 5;
    public int currMissileIndex = 0;

    [SerializeField] public EnemyBullet enemyBullet_prefab;
    private List<EnemyBullet> enemyBulletPool = new List<EnemyBullet>();
    private readonly int enemyBulletMaxCount = 100;
    public int currEnemyBulletIndex = 0;
    private void Awake()
    {
       
    }
    void Start()
    {
        for (int i = 0; i < missileMaxCount; ++i)
        {
            PlayerBullet pb = Instantiate<PlayerBullet>(playerMissile_prefab);
            pb.gameObject.SetActive(false);
            playerMissilePool.Add(pb);
        }

        for(int i = 0; i< enemyBulletMaxCount; ++i)
        {
            EnemyBullet eb = Instantiate<EnemyBullet>(enemyBullet_prefab);
            eb.gameObject.SetActive(false);
            enemyBulletPool.Add(eb);
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

   
    void Update()
    {
        
    }
}
