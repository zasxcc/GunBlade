using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public enum CurrentState {  idle, move, attack, dead };
    private CurrentState currState = CurrentState.idle;

    public int HP;
    public float speed;
    private bool isDead = false;
    public float traceDistance = 15.0f;
    public float attackDistance = 3.2f;


    private NavMeshAgent nvAgent;
    private Transform tr;
    private Transform targetTransform;

    void Awake()
    {

    }

    void Start()
    {
        tr = GetComponent<Transform>();
        nvAgent = GetComponent<NavMeshAgent>();

        //추적할 오브젝트 태그
        targetTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
    
        //추적 position 설정
        nvAgent.destination = targetTransform.position;

        StartCoroutine(CheckState());
    }

    IEnumerator CheckState()
    {
        while(!isDead)
        {
            yield return new WaitForSeconds(0.3f);

            //타겟과의 거리
            float dist = Vector3.Distance(targetTransform.position, tr.position);

            if(dist <= attackDistance)
            {
                currState = CurrentState.attack;

                //애니메이션적용

                //
            }
            else if(dist <= traceDistance)
            {
                currState = CurrentState.move;

                //애니메이션적용

                //
            }
            else
            {
                currState = CurrentState.idle;

                //애니메이션적용

                //
            }
        }
    }


    void Update()
    {
        if (!isDead)
        {
            switch (currState)
            {
                case CurrentState.idle:
                    //nvAgent.Stop();
                    break;
                case CurrentState.move:
                    nvAgent.SetDestination(targetTransform.position);
                    //nvAgent.Resume();
                    break;
                case CurrentState.attack:
                    break;
            }
        }
    }
}
