using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveState : PlayerState
{
    public MoveState(JWPlayer _player, string _animName) : base(_player, _animName)
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
        base.Update();

        player.playerAgent.SetDestination(player.targetPosition);
        if (!player.playerAgent.pathPending && player.playerAgent.remainingDistance <= player.playerAgent.stoppingDistance)
        {
            if (!player.playerAgent.hasPath || player.playerAgent.velocity.sqrMagnitude == 0f)
            {
                player.stateMachine.ChangeState(player.idle);
            }
        }
        
    }
}
