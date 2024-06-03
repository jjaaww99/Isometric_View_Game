using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class JWPlayer : MonoBehaviour
{
    public Animator anim;
    public Rigidbody rb;
    public Collider[] targetsInRange;
    private int maxTargets = 10;
    public LayerMask enemyLayer;

    #region States
    public StateMachine machine;
    public IdleState idle;
    public MoveToTargetState moveToTarget;
    public EvadeState evade;
    public BasicAttackState basicAttack;
    #endregion

    #region MoveData
    [Header("MoveData")]
    public MousePointer mousePointer;
    public NavMeshAgent nav;
    public Vector3 clickPosition;
    public Vector3 mousePosition;
    #endregion

    #region PlayerData
    public float attackRange = 2.3f;
    public float rbForce = 2f; 
    public float evadeForce = 6f;
    #endregion

#nullable enable
    public GameObject? pointedTarget;
    public GameObject? clickedTarget;
#nullable disable

    public bool isMouseOnEnemy;

    public void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        #region States
        machine = new StateMachine();
        idle = new IdleState(this, "Idle");
        moveToTarget = new MoveToTargetState(this, "ToTarget");
        evade = new EvadeState(this, "Evade");
        basicAttack = new BasicAttackState(this, "BasicAttack");
        #endregion
    }

    private void Start()
    {
        machine.Init(idle);
        targetsInRange = new Collider[maxTargets];
        clickPosition = transform.position;
    }

    public float clickDistance;
    public float targetDistance;

    private void Update()
    {
        mousePosition = mousePointer.transform.position;

        clickDistance = Vector3.Distance(clickPosition, transform.position);
        anim.SetFloat("distance", clickDistance);

        machine.currentState.Update();

        if(pointedTarget != null)
        {
            targetDistance = Vector3.Distance(transform.position, pointedTarget.transform.position);
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            anim.SetTrigger("JumpAttack");
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            anim.SetTrigger("WhirlWind");
        }
    }

    private void FixedUpdate()
    {
        machine.currentState.FixedUpdate();
    }

    public Transform basicAttackPoint;
    public float basicAttackRadius;
    public float jumpAttackRadius;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, jumpAttackRadius);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(basicAttackPoint.position, basicAttackRadius);
    }

    public bool damageTrigger = false;
    public bool animTrigger = false;

    public void DamageTrigger() => damageTrigger = !damageTrigger;
    public void AnimTrigger() => animTrigger = !animTrigger;
}

