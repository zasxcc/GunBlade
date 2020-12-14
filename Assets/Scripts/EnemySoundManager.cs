using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoundManager : MonoBehaviour
{
    public AudioSource myAudio;
    public AudioClip enemyGunSound;

    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayEnemyGunSound()
    {
        myAudio.PlayOneShot(enemyGunSound);
    }
}
