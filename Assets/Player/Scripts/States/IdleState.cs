using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class IdleState : PlayerState
{
    public IdleState(JWPlayerController _player, string _animName) : base(_player, _animName)
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

    bool isCoroutineStarted = false;
    public override void Update()
    {
        base.Update();

            
        for(int i = 0; i < player.skillKeyCodes.Length; i++)
        {
            if (Input.GetKey(player.skillKeyCodes[i]))
            {
                machine.ChangeState(player.skill);
            }
        }

        if (player.moveDistance <= 0.1f)
        {
            player.nav.ResetPath();
        }

        if (Input.GetMouseButtonDown(1))
        {

            if(!player.isPointerOnObject)
            {
                player.targetPosition = player.pointerPosition;

                player.nav.SetDestination(player.targetPosition);
            }

            else if(player.clickedTarget.TryGetComponent<Coin>(out Coin coin))
            {
                coin.StartCoroutine(coin.GetCoin());
            }

            else if(player.clickedTarget.TryGetComponent<MonsterStateManager>(out MonsterStateManager monster))
            {
                if (player.targetDistance <= player.attackRange)
                {
                    machine.ChangeState(player.basicAttack);
                }

                else
                {
                    machine.ChangeState(player.moveToTarget);
                }
            }
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            machine.ChangeState(player.evade);
        }
    }
}
