using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : StateMachineAvatar
{
    private GenericStateMachine stateMachine;
    public Vector3 targetPosition;
    public PlayerController player;

    [SerializeField] private const float detectRange = 10f;
    [SerializeField] private const float attackRange = 1f;
    [SerializeField] private float remainingDistance;
    
    [SerializeField] public float targetDistance;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        rigidBody = GetComponent<Rigidbody>();
        stateMachine = new GenericStateMachine(this);
    }

    private void Start()
    {
        stateMachine.Initialize(stateMachine.idle);
        targetPosition = transform.position;
    }

    private void Update()
    {
        targetPosition = player.transform.position;
        targetDistance = Vector3.Distance(transform.position, targetPosition);

        AnimatorParameter();

        IState newState = DetermineState();

        if (newState != stateMachine.currentState)
        {
            stateMachine.ChangeState(newState);
        }

        stateMachine.currentState.Update();

        Debug.Log(stateMachine.currentState);
    }

    void AnimatorParameter()
    {
        remainingDistance = navMeshAgent.remainingDistance;
        animator.SetFloat("targetDistance", remainingDistance);
    }

    private IState DetermineState()
    {
        if(targetDistance <= attackRange)
        {
            stateMachine.attack.SetTarget(targetPosition);
            return stateMachine.attack;
        }
        else if(targetDistance <= detectRange)
        {
            stateMachine.idle.SetDestination(targetPosition);
        }
        else if(targetDistance >= detectRange)
        {
            return stateMachine.idle;
        }

        return stateMachine.idle;
    }
}
