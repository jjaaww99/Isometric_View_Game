using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class JWPlayer : MonoBehaviour
{
    public Animator anim;
    public Rigidbody rb;

    public StateMachine stateMachine;
    public IdleState idle;
    public EvadeState evade;
    public BasicAttackState basicAttack;

    public TargetObject targetObject;

    #region MoveData
    [Header("MoveData")]
    public Camera mainCamera;
    public NavMeshAgent nav;
    public Vector3 clickPosition;
    public Vector3 mousePosition;
    public MousePointer mousePointer;
    #endregion

    #region PlayerData
    public float attackRange = 1.5f;
    #endregion

    public bool isOnEnemy() => mousePointer.isOnEnemy;

    public float distance;

    public void Awake()
    {
        mainCamera = Camera.main;
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        stateMachine = new StateMachine();
        idle = new IdleState(this, "Idle");
        evade = new EvadeState(this, "Evade");
        basicAttack = new BasicAttackState(this, "BasicAttack");
    }

    private void Start()
    {
        stateMachine.Init(idle);
        clickPosition = transform.position;
    }

    private void Update()
    {
        mousePosition = mousePointer.transform.position;
        distance = Vector3.Distance(clickPosition, transform.position);
        anim.SetFloat("distance", distance);

        stateMachine.currentState.Update();
        targetObject = mousePointer.target;
    }
}

