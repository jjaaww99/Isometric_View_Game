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

        if (player.clickedTarget != null)
        {
            targetDir = player.clickedTarget.transform.position - player.transform.forward;
        }

        player.transform.LookAt(targetDir);

    }

    public override void Exit()
    {
        base.Exit();

        player.effects[0].SetActive(false);
    }

    public override void Update()
    {
        base.Update();

        if (player.effectTrigger)
        {
            player.effects[0].SetActive(true);
        }

        if ((Input.GetMouseButton(1) && !player.isPointerOnEnemy) || player.animTrigger)
        {
            machine.ChangeState(player.idle);
        }
    }

    int targets;

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        targets = Physics.OverlapSphereNonAlloc(player.basicAttackBase.position, player.basicAttackRadius, player.targetsInRange);

        if (player.damageTrigger)
        {
            Effect();
        }
    }

    protected void Effect()
    {
        //foreach (var target in player.targetsInRange)
        //{
        //    Vector3 direction = target.transform.position - player.transform.position;

        //    Rigidbody rb = target.GetComponent<Rigidbody>();

        //    if(target.TryGetComponent<MonsterStateManager>(out MonsterStateManager monster))
        //    {
        //        enemy = monster;

        //        monster.MonsterDead();
        //    }

        //    if (target != null)
        //    {
        //        rb.AddForce(direction.normalized * player.rbForce, ForceMode.VelocityChange);
        //    }
        //}

        for (int i = 0; i < targets; i++)
        {
            Vector3 direction = player.targetsInRange[i].transform.position - player.transform.position;

            if (player.targetsInRange[i].TryGetComponent<Rigidbody>(out Rigidbody rb))
            {
                if (player.targetsInRange[i].TryGetComponent<MonsterStateManager>(out MonsterStateManager monster))
                {
                    enemy = monster;

                    monster.MonsterDead();
                }

                rb.AddForce(direction.normalized * player.rbForce, ForceMode.VelocityChange);
            }
        }
    }
}
