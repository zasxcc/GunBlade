using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;
    public Transform firePos;

    public ParticleSystem psBullet;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            ShotRayBullet();
        }
        psBullet.Play();
    }
    private void ShotRayBullet()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hitInfo = new RaycastHit();
        
        if(Physics.Raycast(ray, out hitInfo))
        {
            psBullet.transform.position = hitInfo.point;
            psBullet.transform.forward = hitInfo.normal;

            psBullet.Play();
        }
    }
}
