using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttackState : PlayerState
{
    public BasicAttackState(JWPlayer _player, string _animName) : base(_player, _animName)
    {
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
        if (Input.GetKey(KeyCode.Mouse1) && !player.isOnEnemy())
        {
            machine.ChangeState(player.idle);
        }
    }
}
