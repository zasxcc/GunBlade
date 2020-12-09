using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public enum CurrentState {  idle, move, attack, dead };
    private CurrentState currState = CurrentState.idle;

    public float HP = 100.0f;
    public float speed;
    private bool isDead = false;
    public float attackDistance = 10.0f;

    public int attackTimer = 0;
    public Transform firePos;

    private NavMeshAgent nvAgent;
    private Transform tr;
    private Transform targetTransform;
    private Transform playerTransform;
    private Animator anim;
    private ObjectPool op;

    public ParticleSystem DeadParticlePrefab;

    void Awake()
    {

    }

    void Start()
    {
        tr = GetComponent<Transform>();
        nvAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        op = GameObject.FindObjectOfType<ObjectPool>();

        //추적할 오브젝트 태그
        targetTransform = GameObject.FindWithTag("NavTarget").GetComponent<Transform>();
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();

        //추적 position 설정
        nvAgent.destination = targetTransform.position;

        StartCoroutine(CheckState());
    }

    IEnumerator CheckState()
    {
        while(!isDead)
        {
            yield return new WaitForSeconds(0.1f);

            //타겟과의 거리
            float dist = Vector3.Distance(targetTransform.position, tr.position);

            if(dist <= attackDistance)
            {
                currState = CurrentState.attack;
                nvAgent.Stop();
                //애니메이션적용
                anim.SetBool("isRunning", false);
                anim.SetBool("isAttacking", true);

            }
            else if(dist > attackDistance)
            {
                currState = CurrentState.move;

                //애니메이션적용
                anim.SetBool("isRunning", true);
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
        if(HP <= 0.0f)
        {
            isDead = true;
        }

        if (!isDead)
        {
            switch (currState)
            {
                case CurrentState.idle:
                    nvAgent.Stop();
                    break;

                case CurrentState.move:
                    nvAgent.SetDestination(targetTransform.position);
                    nvAgent.Resume();
                    break;

                case CurrentState.attack:
                    //HP에따라 타겟 설정
                    if (HP > 70.0f)
                        transform.LookAt(targetTransform);
                    else if (HP <= 70.0f)
                    {
                        transform.LookAt(playerTransform);
                    }

                    if (attackTimer > 100)
                    {
                        op.currEnemyBulletIndex++;
                        if (op.currEnemyBulletIndex >= op.GetEnemyBulletMaxCount())
                        {
                            op.currEnemyBulletIndex = 0;
                        }
                        attackTimer = 0;
                        op.EnemyBulletCreate(op.currEnemyBulletIndex, firePos);
                    }
                    attackTimer++;
                    break;
            }
        }
        //죽을때
        else
        {
            GameManager.instance.AddScore(10);
            Instantiate(DeadParticlePrefab.gameObject, firePos.position, Quaternion.FromToRotation(Vector3.forward, tr.forward));
            Destroy(this.gameObject);
        }
    }
}
