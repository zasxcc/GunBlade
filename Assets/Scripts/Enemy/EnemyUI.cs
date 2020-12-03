using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    private EnemyController enemyController;
    private Canvas canvas;
    public Transform playerTransform;
    Slider sliderHP;
    void Start()
    {
        canvas = GetComponent<Canvas>();
        enemyController = GetComponentInParent<EnemyController>();
        sliderHP = GetComponentInChildren<Slider>();
    }

    void LateUpdate()
    {
        canvas.transform.LookAt(playerTransform);
        sliderHP.value = enemyController.HP;
        
    }
}
