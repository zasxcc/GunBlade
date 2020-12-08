using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Slider sliderHP;
    public Slider heatGage;
    public PlayerController player;
    public PlayerFire playerFire;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        playerFire = GameObject.FindWithTag("Player").GetComponent<PlayerFire>();
    }

    void Update()
    {
        sliderHP.value = player.HP;
        heatGage.value = playerFire.heatGage;
    }
}
