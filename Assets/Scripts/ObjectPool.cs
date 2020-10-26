using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] public PlayerBullet playerMissile_prefab;
    private List<PlayerBullet> playerMissilePool = new List<PlayerBullet>();
    private readonly int missileMaxCount = 5;
    public int currMissileIndex = 0;
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

   
    void Update()
    {
        
    }
}
