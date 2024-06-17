using NUnit.Framework.Constraints;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public enum MonsterType
{
    Zombie,
    Bear,
    Normal
}

public class MonsterStateManager : PointableObject
{
    [Header("Components")]
    public NavMeshAgent nav;
    public Rigidbody rigid;
    public Collider bodyCollider;
    public Animator ani;
    public BoxCollider attackArea;
    public BoxCollider detectArea;
    public RagDoll ragdoll;

    [Header("States")]
    MonsterBasicState currentState;
    public MonsterIdleState idleState = new MonsterIdleState();
    public MonsterWanderState wanderState = new MonsterWanderState();
    public MonsterChaseState chaseState = new MonsterChaseState();
    public MonsterAttackState attackState = new MonsterAttackState();
    public MonsterHitState hitState = new MonsterHitState();
    public MonsterDeadState deadState = new MonsterDeadState();

    [Header("Attributes")]
    public MonsterDB monsterDB;
    private int excelDBNumber;
    public string monsterName;
    public MonsterType monsterType;
    public int maxHp;
    public int currentHp;
    private float movementSpeed;
    private int attackPower;

    [Header("Status")]
    public Transform target;
    public float deadCount;
    public bool isDead;
    public bool isHit;
    public float distanceToTarget;
    public float chagetowandertime;

    void Awake()
    {
        bodyCollider = GetComponent<Collider>();
        nav = GetComponent<NavMeshAgent>();
        multipleRenderers = GetComponentsInChildren<SkinnedMeshRenderer>();

        InitializeFromDB(excelDBNumber);

        // 몬스터 타입에 따라 공격 상태를 설정
        switch (monsterType)
        {
            case MonsterType.Zombie:
                attackState = new ZombieAttackState();
                break;
            case MonsterType.Bear:
                chaseState = new BearChaseState();
                break;
            default:
                attackState = new MonsterAttackState();
                chaseState = new MonsterChaseState();
                break;
        }
    }


    protected override void OnEnable()
    {
        base.OnEnable();

        // 초기 상태 설정
        deadCount = 10;
        currentHp = maxHp;
        nav.speed = movementSpeed;
        isDead = false;
        gameObject.SetActive(true);
        ani.enabled = true;
        ragdoll.SetRagdollActive(false);
        rigid.isKinematic = false;
        bodyCollider.enabled = true;
        currentState = idleState;
        currentState.EnterState(this);
        distanceToTarget = 30;
        chagetowandertime = 0f;
    }


    void Update()
    {
        currentState.UpdateState(this);
       
        if (target != null && !isDead)
        {
            nav.enabled = true;
            distanceToTarget = Vector3.Distance(transform.position, target.position);
            ani.SetFloat("targetDistance", distanceToTarget);
        }

        // 상태 변환 조건
        if (currentHp <= 0 && !isDead)
        {
            TryChangeState(deadState);
        }
        else if (isHit && !isDead)
        {
            TryChangeState(hitState);
        }
        else if (distanceToTarget > 15 && !isDead && chagetowandertime < 2 && !isHit)
        {
            TryChangeState(idleState);
        }
        else if (distanceToTarget > 15 && !isDead && chagetowandertime >= 2 && !isHit)
        {
            TryChangeState(wanderState);
        }
        else if (distanceToTarget > 2 && distanceToTarget <= 15 && !isDead && !isHit)
        {
            TryChangeState(chaseState);
        }
        else if (distanceToTarget <= 2 && !isDead && !isHit)
        {
            TryChangeState(attackState);
        }



    }

    public void TryChangeState(MonsterBasicState newState) //동일상태에서 재귀하는걸 방지
    {
        if (currentState != newState)
        {
            ChangeState(newState);
        }
    }

    public void ChangeState(MonsterBasicState state)
    {
        currentState.ExitState(this);
        currentState = state;
        state.EnterState(this);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            JWPlayerController player = other.GetComponent<JWPlayerController>();
            target = player.transform;
        }
    }


    private void InitializeFromDB(int index)
    {
        if (monsterDB != null && index >= 0 && index < monsterDB.Monster.Count)
        {
            MonsterEntity monsterData = monsterDB.Monster[index];
            monsterName = monsterData.name;
            maxHp = monsterData.maxHp;
            movementSpeed = monsterData.speed;
            attackPower = monsterData.atk;
        }
    }

    // 플레이어의 공격을 처리하는 메서드
    public void MonsterHit()
    {
        ChangeState(hitState);
    }

    public void DamagetoPlayer()
    {
        GameManager.instance.player.currentHp -= attackPower;
    }

}
