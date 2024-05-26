using System;
using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    [SerializeField] private int MaxHp;   // 최대 체력
    [SerializeField] private int Hp;      // 현재 체력
    [SerializeField] private int Atk;     // 공격력
    [SerializeField] private float Speed; // 이동속도

    [SerializeField] private Animator ani;              // 거미의 애니메이션
    [SerializeField] private NavMeshAgent nav;          // 거미의 네비게이션
    [SerializeField] private Transform target;          // 이동 목표의 좌표

    [SerializeField] private Collider MonsterCollider;  // 거미 객체의 콜라이더
    [SerializeField] private Collider detectRange;      // 감지 범위 콜라이더
    [SerializeField] private Collider AtkRange;         // 공격 범위 콜라이더

    Rigidbody rigid;

    [SerializeField] private MonsterDB MonsterDB;       // 몬스터 데이터베이스

    [SerializeField] private float Cooltime = 1f;       // 공격 쿨타임
    [SerializeField] private bool IsAttacking;          // 공격 유무 확인
    [SerializeField] private bool IsChasing = false;    // 이동 유무 확인

    private void Awake()
    {
        ani = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        MonsterCollider = GetComponent<Collider>();
        rigid = GetComponent<Rigidbody>();
        InitializeFromDB(0);
    }

    private void Start()
    {
        Hp = MaxHp;
        nav.speed = Speed;
    }

    private void FixedUpdate()
    {
        if (IsChasing)
        {
            Move();
        }
        FreezeVelocity();
    }

    private void FreezeVelocity()
    {
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other == detectRange)
            {
                IsChasing = true;
                IsAttacking = false;
            }
            else if (other == AtkRange)
            {
                IsChasing = false;
                IsAttacking = true;
                StartCoroutine(AttackCoroutine());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other == detectRange)
            {
                IsChasing = false;
                ani.SetBool("Walk", false);
            }
            else if (other == AtkRange)
            {
                IsAttacking = false;
            }
        }
    }

    private IEnumerator AttackCoroutine() // 공격 쿨타임을 적용한 코루틴
    {
        while (IsAttacking)
        {
            ani.SetBool("Attack", true);
            yield return new WaitForSeconds(Cooltime);
        }
    }

    private void Move()
    {
        nav.SetDestination(target.position);
        ani.SetBool("Walk", true);

        // 목표에 도달했는지 확인하고 애니메이션 설정
        if (nav.remainingDistance <= nav.stoppingDistance)
        {
            ani.SetBool("Walk", false);
        }
    }

    private void InitializeFromDB(int index) // 몬스터 데이터베이스에서 정보 불러오는 메서드
    {
        if (index >= 0 && index < MonsterDB.Monster.Count)
        {
            MonsterEntity spiderData = MonsterDB.Monster[index];
            name = spiderData.name;
            MaxHp = spiderData.maxHp;
            Speed = spiderData.speed;
            Atk = spiderData.atk;
        }
    }
}
