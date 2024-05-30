using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvadeState : PlayerState
{
    public EvadeState(JWPlayer _player, string _animName) : base(_player, _animName)
    {
    }


    public override void Enter()
    {
        base.Enter();

        targetPos = player.mousePosition - player.transform.position;

        targetDir = player.mousePosition - player.transform.forward;

        stateTimer = 0.5f;

        player.transform.LookAt(targetDir);
    }

    public override void Exit()
    {
        base.Exit();

    }

    public override void Update()
    {
        base.Update();
        
        player.rb.AddForce(targetPos.normalized * 5, ForceMode.Impulse);

        stateTimer -= Time.deltaTime;

        if(stateTimer <= 0)
        {
            machine.ChangeState(player.idle);
        }
    }
}
