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

    public GameObject[] effects;

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

    public bool isPointerOnEnemy;

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
        foreach (var effect in effects)
        {
            effect.SetActive(false);
        }

        machine.Init(idle);
        //targetsInRange = new Collider[maxTargets];
        clickPosition = transform.position;
    }

    public float clickDistance;
    public float targetDistance;

    private void Update()
    {
        mousePosition = mousePointer.transform.position;

        clickDistance = Vector3.Distance(clickPosition, transform.position);

        if(pointedTarget != null)
        {
            targetDistance = Vector3.Distance(transform.position, pointedTarget.transform.position);
        }
        
        anim.SetFloat("ClickDistance", clickDistance);
        anim.SetFloat("TargetDistance", targetDistance);

        machine.currentState.Update();

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
    public void DamageTrigger() => damageTrigger = !damageTrigger;
    public void AnimTrigger() => animTrigger = !animTrigger;
    public void EffectTrigger() => effectTrigger = !effectTrigger;
}

