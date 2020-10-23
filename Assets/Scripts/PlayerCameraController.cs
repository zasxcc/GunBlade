using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCameraController : MonoBehaviour
{
    public float mouseSensitivity = 2f;
    public float upDownRange = 90;
    private float rotLeftRight;
    private float verticalRotation = 0f;


    void Start()
    {
        //커서 숨기고 잠그기
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //좌우 회전
        rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0f, rotLeftRight, 0f);

        //상하 회전
        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);

    }
}
