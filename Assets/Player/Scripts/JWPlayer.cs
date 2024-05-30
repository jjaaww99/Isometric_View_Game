using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class JWPlayer : MonoBehaviour
{
    public Animator anim;
    public Rigidbody rb;

    #region States
    public StateMachine machine;
    public IdleState idle;
    public MoveToTargetState moveToTarget;
    public EvadeState evade;
    public BasicAttackState basicAttack;
    #endregion
    #region MoveData
    [Header("MoveData")]
    public Camera mainCamera;
    public NavMeshAgent nav;
    public Vector3 clickPosition;
    public Vector3 mousePosition;
    public MousePointer mousePointer;
    #endregion
    #region PlayerData
    public float attackRange = 2.3f;
    public float evadeForce = 6f;
    #endregion

#nullable enable
    public ClickableObject? target;
#nullable disable

    public bool EnemyTargeted() => mousePointer.isOnEnemy;

    public float clickDistance;
    public float targetDistance;

    public void Awake()
    {
        mainCamera = Camera.main;
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        #region States
        machine = new StateMachine();
        idle = new IdleState(this, "Idle");
        moveToTarget = new MoveToTargetState(this, "ToTarget");
        evade = new EvadeState(this, "Evade");
        basicAttack = new BasicAttackState(this, "BasicAttack");
        #endregion

        machine.Init(idle);
        
        clickPosition = transform.position;
    }

    private void Update()
    {
        mousePosition = mousePointer.transform.position;
        clickDistance = Vector3.Distance(clickPosition, transform.position);
        anim.SetFloat("distance", clickDistance);
        target = mousePointer.target;

        machine.currentState.Update();

        if(target != null)
        {
            targetDistance = Vector3.Distance(transform.position, target.transform.position);
        }
    }
}

