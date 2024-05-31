using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTargetState : PlayerState
{
    public MoveToTargetState(JWPlayer _player, string _animParameter) : base(_player, _animParameter)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player.nav.SetDestination(player.target.transform.position);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (player.targetDistance <= player.attackRange)
        {
            machine.ChangeState(player.basicAttack);
        }

        if (Input.GetKey(KeyCode.Mouse1) && !player.EnemyTargeted())
        {
            machine.ChangeState(player.idle);
        }

        if(Input.GetKey(KeyCode.LeftShift))
        {
            machine.ChangeState(player.evade);
        }

        if (Input.GetKey(KeyCode.Mouse1) && player.EnemyTargeted())
        {
            machine.ChangeState(player.moveToTarget);
        }
    }
}
