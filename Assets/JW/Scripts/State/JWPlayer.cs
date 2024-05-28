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
    public Transform mousePointer;
    #endregion


    public float distance;
    public void Awake()
    {
        mainCamera = Camera.main;
        playerAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        
        clickPosition = transform.position;
    }

    private void Update()
    {
        anim.SetFloat("distance", distance);

        mousePosition = mousePointer.position;

        if (Input.GetKey(KeyCode.Mouse0))
        {
            clickPosition = mousePointer.position;
        }
        distance = Vector3.Distance(clickPosition, transform.position);


        playerAgent.SetDestination(clickPosition);


        if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetTrigger("Evade");
        }

        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetTrigger("Attack");
        }

        Vector3 playerForward = transform.forward;

        Vector3 mousePos = mousePosition - transform.position;

        float dotProduct = Vector3.Dot(playerForward, mousePos);

        Vector3 crossProduct = Vector3.Cross(playerForward, mousePos);

        if (dotProduct > 0)
        {
            Debug.Log("Cube is in front of the player.");
        }
        else
        {
            Debug.Log("Cube is behind the player.");
        }

        if (crossProduct.y > 0)
        {
            Debug.Log("Cube is to the right of the player.");
        }
        else
        {
            Debug.Log("Cube is to the left of the player.");
        }
    }
}

