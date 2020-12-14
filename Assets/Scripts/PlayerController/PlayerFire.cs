using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject hitSparkPrefab;
    public GameObject hitNullPrefab;
    public GameObject fireEffectPrefab;
    public Transform gunFirePos;
    public Transform missileFirePos;
    private ObjectPool op;

    public Transform flamePosR;
    public Transform flamePosL;
    private bool RLEffect = false;

    private int missileCount = 0;
    public int missileTimer = 0;

    public int heatGage = 0;
    public int heatGageSpeed = 1;
    public int maxHeatGage = 300;

    private bool penalty = false;
    private bool isGunFire = false;
    public float accuracy = 0.000000000f;
    private int gunSoundDelay = 6;

    void Start()
    {
        op = GameObject.FindObjectOfType<ObjectPool>();
    }

    void Update()
    {
        //미니건 
        if (Input.GetButton("Fire1") && heatGage < 300)
        {
            GunFire();
            //산탄원 커짐
            if (accuracy <= 0.067f)
            {
                accuracy += 0.0004f;
            }
            isGunFire = true;

            if (gunSoundDelay > 5)
            {
                SoundManager.instance.PlayGunSound();
                gunSoundDelay = 0;
            }
            gunSoundDelay++;
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
            if (missileTimer > 0)
                missileTimer -= 1;
        }

        if (isGunFire && heatGage < maxHeatGage)
        {
            heatGage += heatGageSpeed;
            penalty = true;
        }
        else if (heatGage == maxHeatGage && penalty)
        {
            heatGage = 400;
            penalty = false;
        }
        else if (!isGunFire && heatGage > 1)
            heatGage -= heatGageSpeed;

        if(Input.GetButtonUp("Fire1"))
        {
            gunSoundDelay = 6;
        }
        
    }
    private void GunFire()
    {
        if (RLEffect)
        {
            GameObject fireEffectR = Instantiate(fireEffectPrefab, flamePosR.position, Quaternion.FromToRotation(Vector3.up, flamePosR.position));
            Destroy(fireEffectR, 1.0f);
            RLEffect = false;
        }
        else
        {
            GameObject fireEffectL = Instantiate(fireEffectPrefab, flamePosL.position, Quaternion.FromToRotation(Vector3.up, flamePosL.position));
            Destroy(fireEffectL, 1.0f);
            RLEffect = true;
        }
        RaycastHit hit;
        if (Physics.Raycast(gunFirePos.position, gunFirePos.transform.forward + Random.onUnitSphere * accuracy, out hit))
        {
            var target = hit.collider.GetComponent<EnemyController>();
            
            if(target != null)
            {
                GameObject hitSpark = Instantiate(hitSparkPrefab, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                Destroy(hitSpark, 1.0f);
                target.HP -= 5.0f;
            }
            else
            {
                GameObject hitNULL = Instantiate(hitNullPrefab, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                Destroy(hitNULL, 1.0f);
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
