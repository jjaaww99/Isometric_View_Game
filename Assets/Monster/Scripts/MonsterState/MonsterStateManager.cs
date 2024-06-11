using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MonsterStateManager : PointableObject
{
    MonsterBasicState currentState;
    public MonsterIdleState idleState = new MonsterIdleState();
    public MonsterChaseState chaseState = new MonsterChaseState();
    public MonsterAttackState attackState = new MonsterAttackState();
    public MonsterHitState hitState = new MonsterHitState();
    public MonsterDeadState deadState = new MonsterDeadState();
    public RagDoll ragdoll;

    [SerializeField] private int excelDBNumber;     //�������� �ҷ��� ������ ��ȣ
    [SerializeField] private string monsterName;    // ��ü �̸�
    public int maxHp;             // �ִ� ü��
    public int currentHp;         // ���� ü��
    [SerializeField] private float speed;           // �̵��ӵ�
    [SerializeField] private int atk;               // ���ݷ�
    public Transform target;                        // �÷��̾��� ��ġ(�ӽ�)

    public float deadCount; //����� ������� �ð�

    public bool isDead;                 //��� ���� Ȯ��
    public bool hit;
    public float targetDistance;

    public BoxCollider attackArea;      //���� ����
    [SerializeField] private MonsterDB monsterDB;
    public NavMeshAgent nav;
    public Rigidbody rigid;
    public Collider bodyCollider;
    public Animator ani;
    public BoxCollider detectArea;      //�ĺ� ����



    void Awake()
    {
        bodyCollider = GetComponent<Collider>();
        nav = GetComponent<NavMeshAgent>();
        InitializeFromDB(excelDBNumber);
        multipleRenderers = GetComponentsInChildren<SkinnedMeshRenderer>();
    }
    

    protected override void OnEnable()
    {
        base.OnEnable();

        deadCount = 10;
        currentHp = maxHp;
        nav.speed = speed;
        isDead = false;
        gameObject.SetActive(true);
        ani.enabled = true;
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
        if (target != null && isDead == false)
        {
            nav.enabled = true;
            targetDistance = Vector3.Distance(transform.position, target.position);
            ani.SetFloat("targetDistance", targetDistance);
        }

        if (currentHp <= 0 && isDead == false)
        {
            Debug.Log("사망");
            ChangeState(deadState);
        }
        else if (targetDistance > 15 && isDead == false)
        {
            ChangeState(idleState);
        }
        else if (targetDistance > 2 && targetDistance <= 15 && isDead == false)
        {
            ChangeState(chaseState);
        }
        else if (targetDistance <= 2 && isDead == false)
        {
            ChangeState(attackState);
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
            speed = monsterData.speed;
            atk = monsterData.atk;
        }
    }//���������� �ҷ����� �޼���


    public void MonsterHit()
    {
        ChangeState(hitState);
    }

}

