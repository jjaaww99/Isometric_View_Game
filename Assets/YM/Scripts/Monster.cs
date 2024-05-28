using System.Collections;
using TreeEditor;
using Unity.Mathematics;
using Unity.VisualScripting;
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

    private NavMeshAgent nav;
    private Rigidbody rigid;
    [SerializeField]private Collider bodycollider;
    public bool detected = false;
    public bool attackRange = false;

    //public bool isInBoundary = false;
    //public bool isInAttackRange = false;

    [SerializeField] private Animator ani;
    [SerializeField] private MonsterDB monsterDB;

    private void Awake()
    {
        bodycollider = GetComponent<Collider>();
        nav = GetComponent<NavMeshAgent>();
        rigid = GetComponent<Rigidbody>();
        InitializeFromDB(0);
    }

    private void Start()
    {
        currentHp = maxHp;
        nav.speed = speed;
    }

    private void FixedUpdate()
    {
        if (detected && !attackRange)
        {
            nav.isStopped = false;
            nav.SetDestination(target.position); // 몬스터 이동 명령
        }
        else if(detected && attackRange)
        {
            nav.isStopped = true;
            ani.SetBool("Walk", false);
        }
            
    }

    private void Update()
    {
        if(detected)
            transform.LookAt(target.position);
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            attackRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            attackRange = false;
        }
    }



    private void InitializeFromDB(int index) // 몬스터 데이터베이스에서 정보 불러오는 메서드
    {
        if (monsterDB != null && index >= 0 && index < monsterDB.Monster.Count)
        {
            MonsterEntity monsterData = monsterDB.Monster[index];
            monsterName = monsterData.name;
            maxHp = monsterData.maxHp;
            speed = monsterData.speed;
            atk = monsterData.atk;
        }
    }


}
