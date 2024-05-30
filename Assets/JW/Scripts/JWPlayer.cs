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

    #region MoveData
    [Header("MoveData")]
    public Camera mainCamera;
    public NavMeshAgent nav;
    public Vector3 clickPosition;
    public Vector3 mousePosition;
    public Vector3 targetPosition;
    public Transform mousePointer;
    #endregion


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
    }

    private void Start()
    {
        stateMachine.Init(idle);
        clickPosition = transform.position;
    }

    private void Update()
    {
        mousePosition = mousePointer.position;
        distance = Vector3.Distance(clickPosition, transform.position);
        anim.SetFloat("distance", distance);

        stateMachine.currentState.Update();

        //if (Input.GetKey(KeyCode.Mouse0))
        //{
        //    clickPosition = mousePosition;

        //    playerAgent.SetDestination(clickPosition);
        //}


        //if (Input.GetKey(KeyCode.LeftShift))
        //{
        //    anim.SetTrigger("Evade");
        //    clickPosition = transform.position;
        //}


        //if(Input.GetKeyDown(KeyCode.Q)) 
        //{
        //    anim.SetBool("Attack2", true);
        //}
        //if(Input.GetKeyUp(KeyCode.Q))
        //{
        //    anim.SetBool("Attack2", false);
        //}

        if (Input.GetKey(KeyCode.Space))
        {
            Vector3 targetPos = (mousePosition - transform.position).normalized;

            rb.AddForce(targetPos * 10, ForceMode.Impulse);
        }

    }
}

