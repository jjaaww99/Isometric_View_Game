using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class StateMachineAvatar : MonoBehaviour
{
    public Animator animator;
    public NavMeshAgent navMeshAgent;
    public Rigidbody rigidBody;
}
