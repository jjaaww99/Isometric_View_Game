using DamageNumbersPro;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class JWPlayerController : MonoBehaviour
{
    public Animator animator;
    public Rigidbody playerRigidbody;
    public Collider[] targetsInAttackRange;
    public Collider[] targetsInDetectRange;
    private const int maxTargetNum = 20;
    public GameObject[] skillVFXs;
    public MousePointer pointer;
    public PlayerStatus playerStat;

    public DamageNumber damageNumber;

    #region States
    public StateMachine stateMachine;
    public IdleState idle;
    public MoveToTargetState moveToTarget;
    public EvadeState evade;
    public BasicAttackState basicAttack;
    public SkillState skill;
    public DeadState dead;
    #endregion

    #region MoveData
    [Header("MoveData")]
    public NavMeshAgent nav;
    public Vector3 targetPosition;
    public Vector3 pointerPosition;
    #endregion

#nullable enable
    public GameObject? clickedTarget;
#nullable disable

    #region PlayerData
    [Header("PlayerData")]
    [SerializeField] public float attackRange = 2.3f;
    [SerializeField] public float rbForce = 2f;
    [SerializeField] public float evadeForce = 6f;
    #endregion

    public bool isPointerOnObject => pointer.isPointerOnObject;

    public KeyCode[] skillKeyCodes = { KeyCode.Q, KeyCode.W };
    public string[] skillNames;
    public Transform[] skillBases;
    public float[] skillRangeRadiuses = { 5f, 2f };

    public Dictionary<KeyCode, string> skillDictionary;
    public void Awake()
    {
        Initialized();
    }

    public void Initialized()
    {
        #region StatesInitialize
        stateMachine = new StateMachine();
        idle = new IdleState(this, "Idle");
        moveToTarget = new MoveToTargetState(this, "ToTarget");
        evade = new EvadeState(this, "Evade");
        basicAttack = new BasicAttackState(this, "BasicAttack");
        skill = new SkillState(this, "Skill");
        dead = new DeadState(this, "Dead");
        #endregion

        nav = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerStat = GetComponent<PlayerStatus>();

        foreach (var effect in skillVFXs)
        {
            effect.SetActive(false);
        }

        targetsInAttackRange = new Collider[maxTargetNum];
        targetsInDetectRange = new Collider[maxTargetNum];

        stateMachine.Init(idle);
    }

    private void Start()
    {
        skillNames = new string[playerStat.skillList.Length];

        for (int i = 0; i < 6; i++)
        {
            if (playerStat.skillList[i] != null)
            {
                skillNames[i] = playerStat.skillList[i].skillName;
            }
        }

        targetPosition = transform.position;
    }

    public float moveDistance;
    public float targetDistance;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (!pointer.isPointerOnObject)
            {
                targetPosition = pointer.pointerPosition;
            }
        }

        clickedTarget = pointer.pointedObject;

        pointerPosition = pointer.transform.position;

        moveDistance = Vector3.Distance(targetPosition, transform.position);

        if(clickedTarget != null)
        {
            targetDistance = Vector3.Distance(clickedTarget.transform.position, transform.position);
        }

        animator.SetFloat("ClickDistance", moveDistance);
        animator.SetFloat("TargetDistance", targetDistance);

        int targets = Physics.OverlapSphereNonAlloc(transform.position, 5f, targetsInDetectRange, LayerMask.GetMask("Enemy"));
        
        stateMachine.currentState.Update();
    }

    private void FixedUpdate()
    {
        stateMachine.currentState.FixedUpdate();
    }

    public Transform basicAttackPoint;
    public Transform whirlWindPoint;
    public Transform jumpAttackPoint;
    public const float detectRadius = 5f;
    public float basicAttackRadius;
    public float jumpAttackRadius;
    public float whirlWindRadius;
    public Vector3 jumpAttackSize;


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectRadius);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(basicAttackPoint.position, basicAttackRadius);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(whirlWindPoint.position, whirlWindRadius);
        Gizmos.color = Color.blue;
        Matrix4x4 rotationMatrix = Matrix4x4.TRS(jumpAttackPoint.position, jumpAttackPoint.rotation, jumpAttackPoint.localScale);
        Gizmos.matrix = rotationMatrix;
        Gizmos.DrawWireCube(Vector3.zero, jumpAttackSize);
    }

    public bool damageTrigger = false;
    public bool animTrigger = false;
    public bool effectTrigger = false;
    public void ToggleDamageTrigger() => damageTrigger = !damageTrigger;
    public void ToggleAnimTrigger() => animTrigger = !animTrigger;
    public void ToggleEffectTrigger() => effectTrigger = !effectTrigger;

    public void DamageToEnemy(MonsterStateManager _monster, int damage)
    {
        MonsterStateManager monster = _monster;

        monster.currentHp -= damage;
    }
}

