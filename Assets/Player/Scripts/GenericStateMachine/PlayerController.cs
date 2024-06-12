using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : StateMachineAvatar
{
    private GenericStateMachine stateMachine;
    public MousePointer pointer;

    [SerializeField] private Vector3 pointerPosition;
    [SerializeField] private float distance;
    [SerializeField] private float evadeForce;

#nullable enable
    public GameObject? clickedTarget;
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


        if(animationTrigger)
        {
            stateMachine.ChangeState(stateMachine.idle);
            animationTrigger = !animationTrigger;
        }

        if (Input.GetMouseButtonDown(1))
        {
            Vector3 clickPosition = pointerPosition;
            GameObject clickedTarget = pointer.pointedObject;
            distance = Vector3.Distance(clickPosition, transform.position);
            animator.SetFloat("ClickDistance", distance);

            if(clickedTarget == null)
            {
                stateMachine.idle.SetDestination(clickPosition);
            }
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

        if (Input.GetButtonDown("Evade"))
        {
            Debug.Log("Evade");
        }
    }

    void AnimatorParameter()
    {
    }

    [SerializeField] private bool animationTrigger = false;
    public void ToggleAnimationTrigger()
    {
        animationTrigger = !animationTrigger;
    }
}
