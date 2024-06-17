using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class AvatorState : IState
{
    protected StateMachineAvatar avatar;
    protected Animator animator;
    protected string animParameter;

    protected Vector3 targetDirection;
    protected Vector3 targetPosition;


    public AvatorState(StateMachineAvatar _avater, string _animParameter)
    {
        avatar = _avater;
        animator = _avater.animator;
        animParameter = _animParameter;
    }

    public virtual void Enter()
    {
        animator.SetBool(animParameter, true);
    }
    public virtual void Exit()
    {
        animator.SetBool(animParameter, false);
        avatar.navMeshAgent.ResetPath();
    }
    public virtual void Update()
    {
        
    }
}
