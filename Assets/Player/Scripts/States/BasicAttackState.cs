using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BasicAttackState : SkillState
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
        base.Update();

        if ((Input.GetKey(KeyCode.Mouse1) && !player.isMouseOnEnemy) || player.animTrigger)
        {
            machine.ChangeState(player.idle);
        }
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        player.targetsInRange = Physics.OverlapSphere(player.basicAttackPoint.position, player.basicAttackRadius, player.enemyLayer);

        if (player.damageTrigger)
        {
            Effect();
        }
    }

    protected void Effect()
    {
        foreach (var target in player.targetsInRange)
        {
            Vector3 direction = target.transform.position - player.transform.position;

            enemy = target.GetComponent<MonsterStateManager>();

            Rigidbody rb = target.GetComponent<Rigidbody>();

            if (target != null)
            {
                rb.AddForce(direction.normalized * player.rbForce, ForceMode.VelocityChange);
            }

        }
    }
}
