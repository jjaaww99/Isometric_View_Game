using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evade : AvatorState
{
    public Evade(StateMachineAvatar _avatar, string _animParameter) : base(_avatar, _animParameter)
    {
    }

    private Vector3 targetDirection;
    private Vector3 targetPosition;
    private float evadeForce;

    public void SetDirection(Vector3 _targetDirection, Vector3 _targetPosition, float _evadeForce)
    {
        targetDirection = _targetDirection;
        targetPosition = _targetPosition;
        avatar.transform.LookAt(targetDirection);
        evadeForce = _evadeForce;
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
        avatar.rigidBody.AddForce(targetPosition.normalized * evadeForce, ForceMode.Impulse);
    }
}
