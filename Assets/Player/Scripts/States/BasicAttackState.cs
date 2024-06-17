using DamageNumbersPro;
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

        if ((Input.GetMouseButton(1) && !player.isPointerOnObject) || player.animTrigger)
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
            player.damageTrigger = false;
        }
    }

    protected void Effect()
    {
        int targets = Physics.OverlapSphereNonAlloc(player.basicAttackPoint.position, player.basicAttackRadius, player.targetsInAttackRange, LayerMask.GetMask("Enemy"));
        
        for (int i = 0; i < targets; i++)
        {
            Vector3 direction = player.targetsInAttackRange[i].transform.position - player.transform.position;
            
            if(player.targetsInAttackRange[i].TryGetComponent<Rigidbody>(out Rigidbody rigidBody))
            {
                rigidBody.AddForce(direction.normalized * player.rbForce, ForceMode.VelocityChange);
                
                if (player.targetsInAttackRange[i].TryGetComponent<MonsterStateManager>(out MonsterStateManager monster))
                {
                    GameManager.instance.DamageToEnemy(monster, player.playerStat.Damage(10));

                    Debug.Log(player.playerStat.Damage(10));

                    Vector3 numberPosition = monster.transform.position + new Vector3(0, 2, 0);

                    DamageNumber damage = player.damageNumber.Spawn(numberPosition, player.playerStat.Damage(10));

                    CameraShake.Instance.Shake(0.5f, 0.5f);
                }
            }

        }
    }
}

