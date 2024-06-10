using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class JWPlayerController : MonoBehaviour
{
    public Animator animator;
    public Rigidbody playerRigidbody;
    public Collider[] targetsInAttackRange;
    private const int maxTargetNum = 20;
    public GameObject[] skillVFXs;
    public MousePointer pointer;
    public PlayerEquipedSkills equipedSkills;
    public EnemyUI enemyUI;


    #region States
    public StateMachine stateMachine;
    public IdleState idle;
    public MoveToTargetState moveToTarget;
    public EvadeState evade;
    public BasicAttackState basicAttack;
    public SkillState skill;
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
    [Header ("PlayerData")]
    [SerializeField] public float attackRange = 2.3f;
    [SerializeField] public float rbForce = 2f;
    [SerializeField] public float evadeForce = 6f;
    #endregion

    public bool isPointerOnEnemy => pointer.isPointerOnTarget;

    public KeyCode[] skillKeyCodes = { KeyCode.Q, KeyCode.W, KeyCode.E, KeyCode.R, KeyCode.Mouse0, KeyCode.Mouse1 };
    public string[] skillNames;
    public Transform[] skillBases;
    public float[] skillRangeRadiuses = { 5f, 2f, 5f, 2f };

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
        #endregion

        nav = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
        equipedSkills = GetComponent<PlayerEquipedSkills>();

        foreach (var effect in skillVFXs)
        {
            effect.SetActive(false);
        }

        targetsInAttackRange = new Collider[maxTargetNum];

        stateMachine.Init(idle);
    }

    private void Start()
    {
        targetPosition = transform.position;
        
        skillNames = new string[equipedSkills.skillList.Length];

        for(int i = 0; i < equipedSkills.skillList.Length; i++)
        {
            skillNames[i] = equipedSkills.skillList[i].skillName;
        }

        foreach(var names in skillNames)
        {
            Debug.Log(names);
        }
    }

    public float moveDistance;
    public float targetDistance;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        { 
            targetPosition = pointer.pointedPosition;
            clickedTarget = pointer.pointedObject;
        }

        pointerPosition = pointer.transform.position;

        moveDistance = Vector3.Distance(targetPosition, transform.position);

        if(clickedTarget != null)
        {
            targetDistance = Vector3.Distance(clickedTarget.transform.position, transform.position);
            enemyUI.gameObject.SetActive(true);
        }
        else
        {
            enemyUI.gameObject.SetActive(false);
        }
        
        animator.SetFloat("ClickDistance", moveDistance);
        animator.SetFloat("TargetDistance", targetDistance);

        stateMachine.currentState.Update();

        Debug.Log(stateMachine.currentState);
    }

    private void FixedUpdate()
    {
        stateMachine.currentState.FixedUpdate();
    }

    public Transform basicAttackPoint;
    public Transform whirlWindPoint;
    public Transform jumpAttackPoint;
    public float basicAttackRadius;
    public float jumpAttackRadius;
    public float whirlWindRadius;
    public Vector3 jumpAttackSize;


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, jumpAttackRadius);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(basicAttackPoint.position, basicAttackRadius);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(whirlWindPoint.position, whirlWindRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, jumpAttackSize);
    }

    public bool damageTrigger = false;
    public bool animTrigger = false;
    public bool effectTrigger = false;
    public void ToggleDamageTrigger() => damageTrigger = !damageTrigger;
    public void ToggleAnimTrigger() => animTrigger = !animTrigger;
    public void ToggleEffectTrigger() => effectTrigger = !effectTrigger;
}

