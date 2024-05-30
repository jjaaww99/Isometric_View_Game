using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : PlayerState
{
    public IdleState(JWPlayer _player, string _animName) : base(_player, _animName)
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

        if(player.distance <= 0.1)
        {
            player.nav.ResetPath();
        }


        if (Input.GetKey(KeyCode.Mouse1))
        {
            player.clickPosition = player.mousePosition;

            player.nav.SetDestination(player.clickPosition);
        }


        if (Input.GetKey(KeyCode.LeftShift))
        {
            machine.ChangeState(player.evade);
        }
    }
}
