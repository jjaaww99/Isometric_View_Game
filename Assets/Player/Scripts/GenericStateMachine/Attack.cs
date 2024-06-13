using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : AvatorState
{
    public Attack(StateMachineAvatar _stateMachineAvatar, string _animParameter) : base(_stateMachineAvatar, _animParameter)
    {
    }

    public void SetTarget(Vector3 _targetPosition)
    {
        targetPosition = _targetPosition;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();  
    }

    public override void Update()
    {
        base.Update();
        avatar.transform.LookAt(targetPosition);
    }
}
