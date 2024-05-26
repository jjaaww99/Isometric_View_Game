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
    public Vector3 targetPosition;
    #endregion

    public IdleState idle;
    public MoveState move;
    public EvadeState evade;

    public void Start()
    {
        mainCamera = Camera.main;
        playerAgent = GetComponentInChildren<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        stateMachine = new StateMachine();

        idle = new IdleState(this, "Idle");
        move = new MoveState(this, "Move");
        evade = new EvadeState(this, "Evade");

        stateMachine.Init(idle);
    }

    private void Update()
    {
        ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        stateMachine.currentState.Update();

        if (Input.GetKey(KeyCode.Mouse1))
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, clickableLayer))
            {
                targetPosition = hit.point;
            }
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetTrigger("Evade");
            
        }

        Debug.Log(stateMachine.currentState);
    }
}

