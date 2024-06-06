using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MonsterStateManager : MonoBehaviour
{
    MonsterBasicState currentState;
    public MonsterIdleState idleState = new MonsterIdleState();
    public MonsterWanderState wanderState = new MonsterWanderState();
    public MonsterChaseState chaseState = new MonsterChaseState();
    public MonsterAttackState attackState = new MonsterAttackState();
    public MonsterHitState hitState = new MonsterHitState();
    public MonsterDeadState deadState = new MonsterDeadState();
    public RagDoll ragdoll;

    [SerializeField] private int excelDBNumber;     //엑셀에서 불러올 데이터 번호
    [SerializeField] private string monsterName;    // 개체 이름
    [SerializeField] private int maxHp;             // 최대 체력
    public int currentHp;         // 현재 체력
    [SerializeField] private float speed;           // 이동속도
    [SerializeField] private int atk;               // 공격력
    public Transform target;                        // 플레이어의 위치(임시)

    public float deadCount; //사망후 사라지는 시간
    public float idleTowanderTime = 3;     //배회로 넘어가는 쿨타임

    public bool isDead;
    public bool hit;
    public float targetDistance;

    public BoxCollider attackArea;      //공격 범위
    [SerializeField] private MonsterDB monsterDB;
    public NavMeshAgent nav;
    public Rigidbody rigid;
    public Collider bodyCollider;
    public Animator ani;
    public BoxCollider detectArea;      //식별 범위
    

    void Awake()
    {
        bodyCollider = GetComponent<Collider>();
        nav = GetComponent<NavMeshAgent>();
        InitializeFromDB(excelDBNumber);
    }
    void OnEnable()
    {
        idleTowanderTime = 3;
        deadCount = 10;
        currentHp = maxHp;
        nav.speed = speed;
        ani.enabled = true;
        isDead = false;
        ragdoll.SetRagdollActive(false);
        rigid.isKinematic = false;
        bodyCollider.enabled = true;
        currentState = idleState;
        currentState.EnterState(this);
    }


    void Start()
    {
       
    }


    void Update()
    {
        currentState.UpdateState(this);
        Debug.Log(currentState);

        //몬스터와 타겟(플레이어 거리 체크)
        if (target != null)
        {
            nav.enabled = true;
            targetDistance = Vector3.Distance(transform.position, target.position);
            ani.SetFloat("targetDistance", targetDistance);
        }
        
        
        if (targetDistance <= 2 && isDead == false)
        {
            ChangeState(attackState);
        }
        else if (targetDistance > 2 && targetDistance < 15 && isDead == false)
        {
            ChangeState(chaseState);
        }
        else if (targetDistance < 15 && isDead == false)
        {
            ChangeState(idleState);
        }

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            JWPlayerController player = other.GetComponent<JWPlayerController>();
            target = player.transform;
        }
    }

    void OnTriggerStay(Collider other)
    {

    }

    void OnTriggerExit(Collider other)
    {

    }

    private void InitializeFromDB(int index)
    {
        if (monsterDB != null && index >= 0 && index < monsterDB.Monster.Count)
        {
            MonsterEntity monsterData = monsterDB.Monster[index];
            monsterName = monsterData.name;
            maxHp = monsterData.maxHp;
            speed = monsterData.speed;
            atk = monsterData.atk;
        }
    }                //엑셀데이터 불러오는 메서드

    public void ChangeState(MonsterBasicState state)
    {
        currentState.ExitState(this);
        currentState = state;
        state.EnterState(this);
    }   //상태 변경 메서드

    public void MonsterDead()
    {
        ChangeState(deadState);
    }                               //사망 상태 호출

    public void MonsterHit()
    {
        ChangeState(hitState);
    }                                 //피격 상태 호출

    


}

