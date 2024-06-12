using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : StateMachineAvatar
{
    private GenericStateMachine stateMachine;
    public Vector3 targetPosition;
    public PlayerController player;

    public bool isPlayerDetected = false;

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
        Debug.Log($"MonsterState : {stateMachine.currentState}");

        targetDistance = Vector3.Distance(targetPosition, transform.position);

        animator.SetFloat("targetDistance", targetDistance);

        if(isPlayerDetected)
        {
            Debug.Log("detected");
            targetPosition = player.transform.position;
            stateMachine.idle.SetDestination(targetPosition);
        }

        stateMachine.currentState.Update();
    }
}
