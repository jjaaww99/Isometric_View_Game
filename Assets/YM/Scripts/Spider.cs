using System;
using UnityEngine;
using UnityEngine.AI;

public class Spider : MonoBehaviour
{
    [SerializeField] private MonsterDB monsterDB;

    [SerializeField] public string name;
    [SerializeField] public int maxHp;
    [SerializeField] private int Hp; // 현재 체력
    [SerializeField] public float speed;
    [SerializeField] public int atk;

    public Transform target; // 네비게이션 타겟
    private NavMeshAgent navigation;
    private Animator anim;
    public Collider detectArea; // 감지 범위 콜라이더
    public Collider attackArea; // 공격 범위 콜라이더
    private bool playerInDetectArea = false;
    private bool playerInAttackArea = false;

    private void Awake()
    {
        navigation = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        InitializeFromDB(0); // 0번 인덱스를 사용하여 Spider 데이터를 가져옴
    }

    private void Start()
    {
        navigation.speed = speed; // 이동 속도 설정
        Hp = maxHp;
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        if (playerInDetectArea && !playerInAttackArea)
        {
            Move();
        }
        if (playerInAttackArea)
        {
            Attack();
        }
        else
        {
            anim.SetBool("Move", false);
        }
    }

    private void Move()
    {
        // 타겟을 향해 이동
        navigation.SetDestination(target.position);
        anim.SetBool("Move", true);

        // 타겟에 도착했는지 검사
        if (navigation.remainingDistance <= navigation.stoppingDistance)
        {
            anim.SetBool("Move", false);
        }
    }

    private void Attack()
    {
        // 공격 애니메이션 실행
        anim.SetTrigger("Attack");
        //플레이어 체력에 공격력만큼 데미지 전달
        //player.hp -= atk;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other == detectArea)
            {
                Debug.Log("플레이어 감지 범위 안에 들어옴");
                playerInDetectArea = true;
            }
            else if (other == attackArea)
            {
                Debug.Log("플레이어 공격 범위 안에 들어옴");
                playerInAttackArea = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other == detectArea)
            {
                Debug.Log("플레이어 감지 범위에서 나감");
                playerInDetectArea = false;
            }
            else if (other == attackArea)
            {
                Debug.Log("플레이어 공격 범위에서 나감");
                playerInAttackArea = false;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        Hp -= damage;
        anim.SetTrigger("Hit");
        if (Hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        anim.SetBool("Die", true);
        gameObject.SetActive(false);
    }

    private void InitializeFromDB(int index)
    {
        if (index >= 0 && index < monsterDB.Monster.Count)
        {
            MonsterEntity spiderData = monsterDB.Monster[index];
            name = spiderData.name;
            maxHp = spiderData.maxHp;
            speed = spiderData.speed;
            atk = spiderData.atk;
        }
    }

}
