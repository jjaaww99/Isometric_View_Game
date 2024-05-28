using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class JWPlayer : MonoBehaviour
{
    public Animator anim;
    public StateMachine stateMachine;


    #region
    [Header("MoveData")]
    public Camera mainCamera;
    public NavMeshAgent playerAgent;
    public LayerMask clickableLayer;
    public Ray ray;
    public RaycastHit hit;
    public Vector3 clickPosition;
    public Vector3 mousePosition;
    public Transform mousePointer;
    #endregion

    public IdleState idle;
    public MoveState move;
    public EvadeState evade;

    public float distance;
    public void Start()
    {
        mainCamera = Camera.main;
        playerAgent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        //stateMachine = new StateMachine();

        //idle = new IdleState(this, "Idle");
        //move = new MoveState(this, "Move");
        //evade = new EvadeState(this, "Evade");

        //stateMachine.Init(idle);
        distance = 0;
    }

    private void Update()
    {
        distance = Vector3.Distance(clickPosition, transform.position);

        anim.SetFloat("distance", distance);

        mousePosition = mousePointer.position;
        
        if (Input.GetKey(KeyCode.Mouse0))
        {
            clickPosition = mousePointer.position;
        }
        playerAgent.SetDestination(clickPosition);


        if(Input.GetKey(KeyCode.Space))
        {
            anim.SetTrigger("Attack");
        }

        //ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        //stateMachine.currentState.Update();

        //if (Input.GetKey(KeyCode.Space))
        //{
        //    anim.SetTrigger("Attack");
        //}

        //if (Input.GetKey(KeyCode.LeftShift))
        //{
        //    anim.SetTrigger("Evade");
            
        //}

    }
}

