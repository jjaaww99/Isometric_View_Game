using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    [SerializeField] private string monsterName;    // 개체 이름
    [SerializeField] private int maxHp;             // 최대 체력
    [SerializeField] private int currentHp;         // 현재 체력
    [SerializeField] private float speed;           // 이동속도
    [SerializeField] private float atk;             // 공격력
    [SerializeField] private Transform target;      // 이동 목표
    [SerializeField] private BoxCollider attackArea;    //공격 범위

    private NavMeshAgent nav;
    private Rigidbody rigid;
    private LayerMask playerLayerMask;
    private bool atkbool;

    private Collider bodycollider;
    [SerializeField] private Animator ani;
    [SerializeField] private MonsterDB monsterDB;
    [SerializeField] private bool isChase;
    [SerializeField] private bool isAttack;

    private void Awake()
    {
        bodycollider = GetComponent<Collider>();
        nav = GetComponent<NavMeshAgent>();
        rigid = GetComponent<Rigidbody>();
        playerLayerMask = LayerMask.GetMask("Player"); //캐싱 성능 최적화
        InitializeFromDB(0);
        Invoke("ChaseStart", 2);
    }

    private void Start()
    {
        currentHp = maxHp;
        nav.speed = speed;
    }

    private void FixedUpdate()
    {
        Targeting();
        FreezeVelocity();
    }

    private void Targeting()
    {
        float targetRadius = 1.5f;
        float targetRange = 2.5f;

        RaycastHit[] rayHits = Physics.SphereCastAll(transform.position, targetRadius, transform.forward, targetRange, playerLayerMask);

        if (rayHits.Length > 0 && !isAttack)
        {
            atkbool = true; // 매번 공격할 때마다 atkbool을 true로 설정
            StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack()
    {
        isChase = false;
        isAttack = true;
        ani.SetBool("Attack", true);

        attackArea.enabled = true; // 공격 시작 시 공격 범위 활성화
        yield return new WaitForSeconds(1.5f);

        attackArea.enabled = false; // 공격 종료 시 공격 범위 비활성화
        yield return new WaitForSeconds(0.5f);

        isChase = true;
        isAttack = false;
        ani.SetBool("Attack", false);

    }
    //공격 코루틴

    private void Update()
    {
        if (nav.enabled)
        {
            nav.SetDestination(target.position);
            nav.isStopped = !isChase;
        }

        Dead(); //사망기능
    }


    private void ChaseStart()   //추적 시작
    {
        isChase = true;
        ani.SetBool("Walk", true);
    }

    private void FreezeVelocity()
    {
        if (isChase)
        {
            rigid.velocity = Vector3.zero;
            rigid.angularVelocity = Vector3.zero;
        }
    }   //이동 중 방향 고정

    private void Dead()
    {
        if (currentHp <= 0)
        {
            ani.SetTrigger("Dead");
            gameObject.SetActive(false);
            isChase = false;
            nav.enabled = false;
        }
    } //사망 기능

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
    } //엑셀 데이터 불러오는 기능
}
