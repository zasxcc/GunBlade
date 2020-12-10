using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    private EnemyController enemyController;
    private Canvas canvas;
    private PlayerController playerTransform;
    Slider sliderHP;
    void Start()
    {
        canvas = GetComponent<Canvas>();
        enemyController = GetComponentInParent<EnemyController>();
        sliderHP = GetComponentInChildren<Slider>();
        playerTransform = GameObject.FindObjectOfType<PlayerController>();
    }

    void LateUpdate()
    {
        canvas.transform.LookAt(playerTransform.transform);
        sliderHP.value = enemyController.HP;
    }
}
