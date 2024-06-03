using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterStateManager : MonoBehaviour
{
    MonsterBasicState currentState;
    public MonsterIdleState idleState = new MonsterIdleState();
    public MonsterChaseState chaseState = new MonsterChaseState();
    public MonsterAttackState attackState = new MonsterAttackState();
    public MonsterHitState hitState = new MonsterHitState();
    public MonsterDeadState deadState = new MonsterDeadState();

    public string monsterName;    // 개체 이름
    public int maxHp;             // 최대 체력
    public int currentHp;         // 현재 체력
    public float speed;           // 이동속도
    public int atk;               // 공격력
    public bool dead;   //사망 버튼
    public bool hit;
    public float deadCount = 3; //사망후 사라지는 시간

    public Transform target;
    public bool isChase;

    public BoxCollider attackArea;    //공격 범위
    public NavMeshAgent nav;
    public Rigidbody rigid;
    public Collider bodyCollider;
    public Animator ani;
    public MonsterDB monsterDB;

    void Awake()
    {
        bodyCollider = GetComponent<Collider>();
        nav = GetComponent<NavMeshAgent>();
        rigid = GetComponent<Rigidbody>();
        InitializeFromDB(0);
    }
    void OnEnable()
    {
        deadCount = 3;
        currentHp = maxHp;
        nav.speed = speed;
        currentState = idleState;
        currentState.EnterState(this);
        dead = false;
    }

    void Start()
    {
       
    }


    void Update()
    {
        currentState.UpdateState(this);
        Debug.Log(currentState);
        if (dead)
            MonsterDead();
        
    }


    public void ChangeState(MonsterBasicState state)
    {
        currentState.ExitState(this);
        currentState = state;
        state.EnterState(this);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            ChangeState(attackState);
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
    }//엑셀데이터 불러오는 메서드

    public void MonsterDead()
    {
        ChangeState(deadState);
    }

    public void MonsterHit()
    {
        ChangeState(hitState);
    }



}

