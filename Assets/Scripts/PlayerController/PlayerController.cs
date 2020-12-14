using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public float rotSpeed = 200.0f;
    public float HP = 100.0f;

    private float mx;
    private float my;

    public Vector3[] wayPoint;
    private Vector3 currPos;
    private int wayPointIndex = 0;
    public float playerMoveSpeed = 5.0f;

    public TargetController tc;

    CharacterController cc;

    void Start()
    {
        //커서 숨기고 잠그기
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        cc = gameObject.GetComponent<CharacterController>();

        wayPoint = new Vector3[6];
        wayPoint.SetValue(new Vector3(5.13f, 14.76f, -20.2f),0);
        wayPoint.SetValue(new Vector3(16.63f, 10.41f, -11.87f), 1);
        wayPoint.SetValue(new Vector3(33.1f, 7.52f, -8.11f), 2);
        wayPoint.SetValue(new Vector3(33.1f, 4.83f, 20.11f), 3);
        wayPoint.SetValue(new Vector3(-6.44f, 7.14f, 20.11f), 4);
        wayPoint.SetValue(new Vector3(9.40f, 7.940f, -5.020f), 5);
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");

        mx += h * rotSpeed * Time.deltaTime;
        my += v * rotSpeed * Time.deltaTime;

        my = Mathf.Clamp(my, -89, 89);
        transform.eulerAngles = new Vector3(-my, mx, 0);


        //이동 경로
        currPos = transform.position;
        if (wayPointIndex < wayPoint.Length)
        {
            float step = playerMoveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(currPos, wayPoint[wayPointIndex], step);

            if (Vector3.Distance(wayPoint[wayPointIndex], currPos) == 0f)
            {
                if (wayPointIndex != 5)
                    wayPointIndex++;
                else if (wayPointIndex == 5)
                    wayPointIndex = 0;
            }
        }

        if(HP < 1.0f || tc.HP <= 0.0f)
        {
            SceneManager.LoadScene("HighScoreScene");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "EnemyBullet(Clone)")
        {
            HP -= 10.0f;
            other.gameObject.SetActive(false);
        }
    }
}
