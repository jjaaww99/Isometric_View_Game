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
    public float rbForce; 

    #region States
    public StateMachine machine;
    public IdleState idle;
    public MoveToTargetState moveToTarget;
    public EvadeState evade;
    public BasicAttackState basicAttack;
    #endregion
    #region MoveData
    [Header("MoveData")]
    private Camera mainCamera;
    public MousePointer mousePointer;
    public NavMeshAgent nav;
    public Vector3 clickPosition;
    public Vector3 mousePosition;
    #endregion
    #region PlayerData
    public float attackRange = 2.3f;
    public float evadeForce = 6f;
    #endregion

#nullable enable
    public ClickableObject? target;
#nullable disable

    public bool EnemyTargeted() => mousePointer.isOnEnemy;

    public void Awake()
    {
        mainCamera = Camera.main;
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
        if(machine.currentState == null)
        {
            machine.Init(idle);
        }

        mousePosition = mousePointer.transform.position;
        clickDistance = Vector3.Distance(clickPosition, transform.position);
        anim.SetFloat("distance", clickDistance);
        target = mousePointer.target;

        machine.currentState.Update();

        if(target != null)
        {
            targetDistance = Vector3.Distance(transform.position, target.transform.position);
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

    public bool animationTrigger = false;
    public void AnimationTrigger() => animationTrigger = !animationTrigger;
}

