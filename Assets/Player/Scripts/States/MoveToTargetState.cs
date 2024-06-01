using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTargetState : PlayerState
{
    public MoveToTargetState(JWPlayer _player, string _animParameter) : base(_player, _animParameter)
    {
    }

    GameObject target;

    public override void Enter()
    {
        base.Enter();

        target = player.clickedTarget;

        player.nav.SetDestination(target.transform.position);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if(!player.isMouseOnEnemy())
            {
                machine.ChangeState(player.idle);
            }

            if(player.clickedTarget != target)
            {
                machine.ChangeState(player.moveToTarget);
            }

            if(player.clickedTarget == target)
            {
                return;
            }
        }

        if (player.targetDistance <= player.attackRange)
        {
            machine.ChangeState(player.basicAttack);
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            machine.ChangeState(player.evade);
        }
    }
}
