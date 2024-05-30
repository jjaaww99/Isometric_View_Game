//using System;
//using System.Collections;
//using UnityEngine;
//using UnityEngine.AI;

//public class MonsterInfo : MonoBehaviour
//{
//    public StateMachine stateMachine;

//    public string monsterName;    // 개체 이름
//    public int maxHp;             // 최대 체력
//    public int currentHp;         // 현재 체력
//    public float speed;           // 이동속도
//    public int atk;             // 공격력
//    public BoxCollider attackArea;    //공격 범위

//    public NavMeshAgent nav;
//    public Rigidbody rigid;

//    public Collider bodycollider;
//    public Animator ani;
//    public MonsterDB monsterDB;

//    private void Awake()
//    {
//        bodycollider = GetComponent<Collider>();
//        nav = GetComponent<NavMeshAgent>();
//        rigid = GetComponent<Rigidbody>();
//        InitializeFromDB(0);
//    }

//    private void Start()
//    {
//        currentHp = maxHp;
//        nav.speed = speed;
//        ChaseStart();
//    }

//    private void FixedUpdate()
//    {

//        FreezeVelocity();   //이동시 방향 고정
//    }

//    private void Update()
//    {
        

//        if (currentHp <= 0)
//            Dead();
//    }


//    void OnTriggerStay(Collider other)
//    {
//        if (other.CompareTag("Player"))
//        {
//            if (!isAttack)
//            {
//                StartCoroutine(Attack());
//            }
//        }
//    }


//    private void ChaseStart()   //추적 시작
//    {
//        isChase = true;
//        ani.SetBool("Walk", true);
//    }

//    private IEnumerator Attack()
//    {
//        if (isAttack) yield break;

//        isChase = false;
//        isAttack = true;
//        ani.SetBool("Attack", true);

//        attackArea.enabled = true; // 공격 시작 시 공격 범위 활성화
//        yield return new WaitForSeconds(1.5f);

//        attackArea.enabled = false; // 공격 종료 시 공격 범위 비활성화
//        yield return new WaitForSeconds(0.5f);

//        isChase = true;
//        isAttack = false;
//        ani.SetBool("Attack", false);

//    }//공격 코루틴

//    private void FreezeVelocity()
//    {
//        if (isChase)
//        {
//            rigid.velocity = Vector3.zero;
//            rigid.angularVelocity = Vector3.zero;
//        }
//    }   //이동 중 방향 고정

//    void Damage(int index)
//    {
//        currentHp -= index;
//        Hit2();
//    } //피격 로직

//    private IEnumerator Hit2()
//    {
//        isChase = false;
//        ani.SetTrigger("TakeDamage");
//        yield return new WaitForSeconds(1.5f);
//        isChase = true;
//    } //피격시 코루틴

//    private void Dead()
//    {
//        ani.SetTrigger("Dead");
//        isChase = false;
//        StartCoroutine(DeadDelay(3f));
//    }   //사망 로직

//    private IEnumerator DeadDelay(float delay)
//    {
//        yield return new WaitForSeconds(delay);
//        gameObject.SetActive(false);
//    } //사망 딜레이(비활성화)

//    private void InitializeFromDB(int index)
//    {
//        if (monsterDB != null && index >= 0 && index < monsterDB.Monster.Count)
//        {
//            MonsterEntity monsterData = monsterDB.Monster[index];
//            monsterName = monsterData.name;
//            maxHp = monsterData.maxHp;
//            speed = monsterData.speed;
//            atk = monsterData.atk;
//        }
//    } //엑셀 데이터 불러오는 기능
//}

