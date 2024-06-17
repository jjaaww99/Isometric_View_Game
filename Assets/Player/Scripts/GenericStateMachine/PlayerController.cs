using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : StateMachineAvatar
{
    private GenericStateMachine stateMachine;
    public MousePointer pointer;

    [SerializeField] private Vector3 pointerPosition;
    [SerializeField] private Vector3 clickedPosition;
    [SerializeField] private float distance;
    [SerializeField] private float evadeForce;

#nullable enable
    [SerializeField] private GameObject? clickedTarget;
#nullable disable

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
        stateMachine.PlayerPackage();
    }


    private void Start()
    {
        stateMachine.Initialize(stateMachine.idle);
    }


    private void Update()
    {
        Debug.Log($"PlayerState : {stateMachine.currentState}");

        Controller();
        AnimatorParameter();

        stateMachine.currentState.Update();
    }

    void Controller()
    {
        pointerPosition = pointer.pointerPosition;
        stateMachine.idle.SetDestination(clickedPosition);

        if (Input.GetMouseButtonDown(1))
        {
            clickedTarget = pointer.pointedObject;
            clickedPosition = pointerPosition;
        }
        else 
        {
            clickedTarget = null;
            clickedPosition = Vector3.zero; 
        }

        if(Input.GetButtonDown("Evade"))
        {
            Vector3 targetDirection = pointerPosition - transform.forward;
            Vector3 targetPosition = pointerPosition - transform.position;
            stateMachine.evade.SetDirection(targetDirection, targetPosition, evadeForce);
            stateMachine.ChangeState(stateMachine.evade);
        }




        if (Input.GetButtonDown("Skill1"))
        {
            Debug.Log("QInput");
        }

        if (Input.GetButtonDown("Skill2"))
        {
            Debug.Log("WInput");
        }

        if (Input.GetButtonDown("Skill3"))
        {
            Debug.Log("EInput");
        }

        if (Input.GetButtonDown("Skill4"))
        {
            Debug.Log("RInput");
        }

        if (animationTrigger)
        {
            stateMachine.ChangeState(stateMachine.idle);
            animationTrigger = !animationTrigger;
        }
    }

    void AnimatorParameter()
    {
        distance = navMeshAgent.remainingDistance;
        animator.SetFloat("ClickDistance", distance);
    }

    [SerializeField] private bool animationTrigger = false;
    public void ToggleAnimationTrigger()
    {
        animationTrigger = !animationTrigger;
    }
}
