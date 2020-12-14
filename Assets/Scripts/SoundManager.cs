using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    AudioSource myAudio;

    public AudioClip playerGunSound;
    public AudioClip explosionSound;

    private void Awake()
    {
        if (SoundManager.instance == null)
            SoundManager.instance = this;
    }

    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }


    void Update()
    {
        
    }

    public void PlayGunSound()
    {
        myAudio.PlayOneShot(playerGunSound);
    }


    public void PlayExplosionSound()
    {
        myAudio.PlayOneShot(explosionSound);
    }
}
