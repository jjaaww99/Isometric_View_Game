using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvadeState : PlayerState
{
    public EvadeState(JWPlayerController _player, string _animName) : base(_player, _animName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        targetPos = player.pointerPosition - player.transform.position;

        targetDir = player.pointerPosition - player.transform.forward;

        player.transform.LookAt(targetDir);

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        
        if(player.animTrigger)
        {
            machine.ChangeState(player.idle);
        }
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        player.playerRigidbody.AddForce(targetPos.normalized * player.evadeForce, ForceMode.Impulse);
        
    }
}
