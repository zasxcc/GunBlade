using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    Slider sliderHP;
    float fSliderBarTime;
    public PlayerController player;

    void Start()
    {
        sliderHP = GetComponent<Slider>();
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        sliderHP.value = player.HP;
    }
}
