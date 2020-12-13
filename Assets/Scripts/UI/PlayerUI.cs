using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Slider sliderHP;
    public Slider heatGage;
    public Slider targetHP;
    public PlayerController player;
    public PlayerFire playerFire;
    public TargetController tc;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        playerFire = GameObject.FindWithTag("Player").GetComponent<PlayerFire>();
        tc = GameObject.FindObjectOfType<TargetController>();
    }

    void Update()
    {
        sliderHP.value = player.HP;
        heatGage.value = playerFire.heatGage;
        targetHP.value = tc.HP;

    }
}
