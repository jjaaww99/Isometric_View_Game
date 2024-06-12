using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class AvatorState : IState
{
    protected StateMachineAvatar avatar;
    protected Animator animator;
    protected string animParameter;

    public AvatorState(StateMachineAvatar _stateMachineAvatar, string _animParameter)
    {
        avatar = _stateMachineAvatar;
        animator = _stateMachineAvatar.animator;
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
