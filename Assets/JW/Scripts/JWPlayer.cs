using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class JWPlayer : MonoBehaviour
{
    public Animator anim;
    public StateMachine stateMachine;


    #region MoveData
    [Header("MoveData")]
    public Camera mainCamera;
    public NavMeshAgent playerAgent;
    public Vector3 clickPosition;
    public Vector3 mousePosition;
    public Vector3 targetPosition;
    public Transform mousePointer;
    #endregion


    public float distance;
    public void Awake()
    {
        mainCamera = Camera.main;
        playerAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        
    }

    private void Start()
    {
        clickPosition = transform.position;
    }

    private void Update()
    {
        anim.SetFloat("distance", distance);

        mousePosition = mousePointer.position;

        if (Input.GetKey(KeyCode.Mouse0))
        {
            clickPosition = mousePosition;

            playerAgent.SetDestination(clickPosition);
        }

        distance = Vector3.Distance(clickPosition, transform.position);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetTrigger("Evade");
            clickPosition = transform.position;
        }

        
        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetTrigger("Attack");
        }

    }
}

