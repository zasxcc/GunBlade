using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform Target;
    public float distance = 10.0f;
    public float height = 3.0f;
    public float dampTrace = 20.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        //커서 숨기고 잠그기
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position,
                                          Target.position - (Target.forward * distance) + (Vector3.up * height)
                                          , Time.deltaTime * dampTrace);
        transform.LookAt(Target.position);
    }
}
