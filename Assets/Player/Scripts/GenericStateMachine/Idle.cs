using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Idle : AvatorState
{
    private Vector3 targetPosition;

    public Idle(StateMachineAvatar _user, string _animParameter) : base(_user, _animParameter)
    {
    }

    public void SetDestination(Vector3 _targetPosition) // 목표 위치 설정해주세요
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
        avatar.navMeshAgent.SetDestination(targetPosition);
    }
}
