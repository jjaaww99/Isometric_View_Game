using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTest : MonoBehaviour
{
    NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(transform.forward);
    }
}
