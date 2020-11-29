using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float rotSpeed = 200.0f;
    public float playerMoveSpeed = 5.0f;
    public float HP = 100.0f;
    private float mx;
    private float my;

    CharacterController cc;

    void Start()
    {
        //커서 숨기고 잠그기
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        cc = gameObject.GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");

        mx += h * rotSpeed * Time.deltaTime;
        my += v * rotSpeed * Time.deltaTime;

        my = Mathf.Clamp(my, -89, 89);
        transform.eulerAngles = new Vector3(-my, mx, 0);

        float h2 = Input.GetAxis("Horizontal");
        float v2 = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h2, 0, v2);
        dir.Normalize();
        dir = Camera.main.transform.TransformDirection(dir);

        cc.Move(dir * playerMoveSpeed * Time.deltaTime);
    }
}
