using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BasicAttackState : PlayerState
{
    public BasicAttackState(JWPlayerController _player, string _animName) : base(_player, _animName)
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

        player.skillVFXs[0].SetActive(false);
    }

    public override void Update()
    {
        base.Update();

        if (player.effectTrigger)
        {
            player.skillVFXs[0].SetActive(true);
        }

        if ((Input.GetMouseButton(1) && !player.isPointerOnEnemy) || player.animTrigger)
        {
            machine.ChangeState(player.idle);
        }
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();


        if (player.damageTrigger)
        {
            Effect();
        }
    }

    protected void Effect()
    {
        int targets = Physics.OverlapSphereNonAlloc(player.basicAttackBase.position, player.basicAttackRadius, player.targetsInAttackRange);
        
        for (int i = 0; i < targets; i++)
        {
            Vector3 direction = player.targetsInAttackRange[i].transform.position - player.transform.position;

            if (player.targetsInAttackRange[i].TryGetComponent<Rigidbody>(out Rigidbody rb))
            {
                if (player.targetsInAttackRange[i].TryGetComponent<MonsterStateManager>(out MonsterStateManager monster))
                {
                    enemy = monster;

                    monster.MonsterDead();
                }

                rb.AddForce(direction.normalized * player.rbForce, ForceMode.VelocityChange);
            }
        }
    }
}
