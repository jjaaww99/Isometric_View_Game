using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class JWPlayerController : MonoBehaviour
{
    public Animator animator;
    public Rigidbody playerRigidbody;
    public Collider[] targetsInAttackRange;
    private const int maxTargetNum = 10;
    public GameObject[] skillVFXs;
    public MousePointer pointer;

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
    public float attackRange = 2.3f;
    public float rbForce = 2f; 
    public float evadeForce = 6f;
    #endregion

    public bool isPointerOnEnemy => pointer.isPointerOnTarget;

    public KeyCode[] skillKeyCodes = { KeyCode.Q, KeyCode.W, KeyCode.E, KeyCode.R };
    public string[] skillNames = { "JumpAttack", "WhirlWind", "JumpAttack", "WhirlWind" };

    public Dictionary<KeyCode, string> skillDictionary;

    public void Awake()
    {
        Initialized();
    }

    public void Initialized()
    {
        #region States
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
    }

    public float moveDistance;
    public float targetDistance;

    private void Update()
    {
        if (Input.GetMouseButton(1))
        { 
            targetPosition = pointer.pointedPosition;
            clickedTarget = pointer.pointedObject;
        }

        pointerPosition = pointer.transform.position;

        moveDistance = Vector3.Distance(targetPosition, transform.position);

        if(clickedTarget != null)
        {
            targetDistance = Vector3.Distance(clickedTarget.transform.position, transform.position);
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

    public Transform basicAttackBase;
    public float basicAttackRadius;
    public float jumpAttackRadius;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, jumpAttackRadius);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(basicAttackBase.position, basicAttackRadius);
    }

    public bool damageTrigger = false;
    public bool animTrigger = false;
    public bool effectTrigger = false;
    public void ToggleDamageTrigger() => damageTrigger = !damageTrigger;
    public void ToggleAnimTrigger() => animTrigger = !animTrigger;
    public void ToggleEffectTrigger() => effectTrigger = !effectTrigger;
}

