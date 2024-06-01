using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BasicAttackState : PlayerState
{
    public BasicAttackState(JWPlayer _player, string _animName) : base(_player, _animName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        if(player.clickedTarget != null)
        {   
            targetDir = player.clickedTarget.transform.position - player.transform.forward;
        }

        player.transform.LookAt(targetDir);
        
        if(player.animTrigger)
        {
            player.AnimTrigger();
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {

        if ((Input.GetKey(KeyCode.Mouse1) && !player.isMouseOnEnemy()) || player.animTrigger)
        {
            machine.ChangeState(player.idle);
        }
    }
}
