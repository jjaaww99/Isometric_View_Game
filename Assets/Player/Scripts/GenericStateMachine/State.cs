using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class ObjectState : IState
{
    public Animator animator;
    public string animParameter;

    public void Enter()
    {
        animator.SetBool(animParameter, true);
    }
    public void Exit()
    {
        animator.SetBool(animParameter, false);
    }
    public void Update()
    {

    }
}
