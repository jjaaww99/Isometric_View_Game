using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkillState : PlayerState
{
    public SkillState(JWPlayerController _player, string _animParameter) : base(_player, _animParameter)
    {
    }

    public int index;

    public override void Enter()
    {
        base.Enter();

        for (int i = 0; i < player.skillKeyCodes.Length; i++)
        {
            if (Input.GetKeyDown(player.skillKeyCodes[i]))
            {
                index = i;
                player.animator.SetBool(player.skillNames[i], true);
            }
        }
    }

    public override void Exit()
    {
        player.animator.SetBool(player.skillNames[index], false);


        base.Exit();
    }
    public override void Update()
    {
        base.Update();

        if (player.animTrigger)
        {
            player.stateMachine.ChangeState(player.idle);
        }
    }
    public override void FixedUpdate()
    {
        if(index == 1)
        {
            EffectCircle();
        }
        else if(index == 0)
        {
            EffectSquare();
        }
    }

    void EffectCircle()
    {
        if (player.damageTrigger)
        {
            int targets = Physics.OverlapSphereNonAlloc(player.skillBases[index].position, player.skillRangeRadiuses[index], player.targetsInAttackRange, LayerMask.GetMask("Enemy"));

            for (int i = 0; i < targets; i++)
            {
                Vector3 direction = player.targetsInAttackRange[i].transform.position - player.transform.position;

                if (player.targetsInAttackRange[i].TryGetComponent<Rigidbody>(out Rigidbody rigidBody))
                {
                    rigidBody.AddForce(direction.normalized * player.rbForce, ForceMode.VelocityChange);

                    if (player.targetsInAttackRange[i].TryGetComponent<MonsterStateManager>(out MonsterStateManager monster))
                    {
                        monster.currentHp -= 1;
                    }
                }
            }
        }
    }

    void EffectSquare()
    {
        if (player.damageTrigger)
        {
            int targets = Physics.OverlapBoxNonAlloc(
                player.jumpAttackPoint.position,
                player.jumpAttackSize / 2, // OverlapBox의 반사이즈를 전달
                player.targetsInAttackRange,
                player.jumpAttackPoint.rotation, // 점프 공격 포인트의 회전을 사용
                LayerMask.GetMask("Enemy"));

            for (int i = 0; i < targets; i++)
            {
                Vector3 direction = player.targetsInAttackRange[i].transform.position - player.transform.position;

                if (player.targetsInAttackRange[i].TryGetComponent<Rigidbody>(out Rigidbody rigidBody))
                {
                    rigidBody.AddForce(direction.normalized * player.rbForce, ForceMode.VelocityChange);

                    if (player.targetsInAttackRange[i].TryGetComponent<MonsterStateManager>(out MonsterStateManager monster))
                    {
                        monster.currentHp -= 1;
                    }
                }
            }
        }
    }

}
