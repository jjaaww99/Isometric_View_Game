using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTargetState : PlayerState
{
    public MoveToTargetState(JWPlayerController _player, string _animParameter) : base(_player, _animParameter)
    {
    }

    GameObject target;

    public override void Enter()
    {
        base.Enter();

        if(player.clickedTarget != null)
        {
            player.nav.SetDestination(player.clickedTarget.transform.position);
        }

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (Input.GetMouseButton(1))
        {
            if(!player.isPointerOnObject)
            {
                machine.ChangeState(player.idle);
            }

            else if(player.clickedTarget != target)
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
