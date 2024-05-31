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

        if(player.target != null)
        {   
            targetDir = player.target.transform.position - player.transform.forward;
        }

        player.transform.LookAt(targetDir);

        stateTimer = 1f;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        stateTimer -= Time.deltaTime;

        if ((Input.GetKey(KeyCode.Mouse1) && !player.EnemyTargeted()) || stateTimer <= 0)
        {
            machine.ChangeState(player.idle);
        }
    }
}
