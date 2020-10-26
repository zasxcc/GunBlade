using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float rotSpeed = 200.0f;
    public float playerMoveSpeed = 5.0f;
    float mx;
    float my;

    CharacterController cc;

    // Start is called before the first frame update
    void Start()
    {
        //커서 숨기고 잠그기
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        cc = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //플레이어 카메러 회전
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");

        mx += h * rotSpeed * Time.deltaTime;
        my += v * rotSpeed * Time.deltaTime;

        my = Mathf.Clamp(my, -89, 89);
        transform.eulerAngles = new Vector3(-my, mx, 0);
        /////
        //플레이어 이동
        float h2 = Input.GetAxis("Horizontal");
        float v2 = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h2, 0, v2);
        dir.Normalize();
        dir = Camera.main.transform.TransformDirection(dir);

        cc.Move(dir * playerMoveSpeed * Time.deltaTime);
    }
}
