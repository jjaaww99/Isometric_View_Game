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

        targetDir = player.target.transform.position - player.transform.forward;

        player.transform.LookAt(targetDir);
    }

    public override void Exit()
    {
        base.Exit();
        player.nav.enabled = true;
    }

    public override void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1) && !player.isOnEnemy())
        {
            machine.ChangeState(player.idle);
        }
    }
}
