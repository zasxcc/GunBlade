using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject hitSparkPrefab;
    public Transform gunFirePos;
    public Transform missileFirePos;
    private ObjectPool op;

    private int missileCount = 0;
    public int missileTimer = 0;

    public int heatGage =0;
    public int heatGageSpeed = 1;
    public int maxHeatGage = 300;

    private bool isGunFire = false;
    public float accuracy = 0.000000000f;

    void Start()
    {
        op = GameObject.FindObjectOfType<ObjectPool>();
    }

    void Update()
    {
        //미니건 
        if (Input.GetButton("Fire1"))
        {
            GunFire();
            //산탄원 커짐
            if (accuracy <= 0.067f)
            {
                accuracy += 0.0004f;
            }
            isGunFire = true;
        }
        else
        {
            //산탄원 회복
            if (accuracy > 0.00000f)
                accuracy -= 0.0004f;
            isGunFire = false;
        }
        //미사일
        if (Input.GetButton("Fire2") && missileTimer == 0)
        {
            FireMissile();
            missileTimer = 50;
        }
        else
        {
            if(missileTimer>0)
                missileTimer -= 1;
        }

        if (isGunFire && heatGage < maxHeatGage)
            heatGage += heatGageSpeed;
        else if (!isGunFire && heatGage > 1)
            heatGage -= heatGageSpeed;
        
    }
    private void GunFire()
    {
        RaycastHit hit;
        if (Physics.Raycast(gunFirePos.position, gunFirePos.transform.forward + Random.onUnitSphere * accuracy, out hit))
        {
            GameObject hitSpark = Instantiate(hitSparkPrefab, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
            Destroy(hitSpark, 1.0f);

            
            var target = hit.collider.GetComponent<EnemyController>();
            if(target != null)
            {
                target.HP -= 1.0f;
            }
        }
        
    }
    private void FireMissile()
    {
        missileCount++;
        if (missileCount >= op.GetPlayerBulletMaxCount())
        {
            missileCount = 0;
        }
        op.PlayerMissileCreate(missileCount, missileFirePos);
    }
}
