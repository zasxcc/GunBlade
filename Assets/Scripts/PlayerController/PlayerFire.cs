using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject hitSparkPrefab;
    public Transform firePos;
    private ObjectPool op;

    private int missileCount = 0;
    private float range;
    public int missileTimer = 0;
    public float accuracy = 0.000f;

    void Start()
    {
        op = GameObject.FindObjectOfType<ObjectPool>();
    }

    void Update()
    {
        if(Input.GetButton("Fire2") && missileTimer == 0)
        {
            FireMissile();
            missileTimer = 50;
        }
        else
        {
            if(missileTimer>0)
                missileTimer -= 1;
        }

        if(Input.GetButton("Fire1"))
        {
            GunFire();
            accuracy += 0.0002f;
        }
        else
        {
            if(accuracy > 0.00f)
                accuracy -= 0.0003f;
        }
    }
    private void GunFire()
    {
        RaycastHit hit;
        if (Physics.Raycast(firePos.position, firePos.transform.forward + Random.onUnitSphere * accuracy, out hit))
        {
            GameObject hitSpark = Instantiate(hitSparkPrefab, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
            Destroy(hitSpark, 0.5f);
        }
    }
    private void FireMissile()
    {
        missileCount++;
        if (missileCount >= op.GetPlayerBulletMaxCount())
        {
            missileCount = 0;
        }
        op.PlayerMissileCreate(missileCount, firePos);
    }
}
