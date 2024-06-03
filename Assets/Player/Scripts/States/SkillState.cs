using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillState : PlayerState
{
    public SkillState(JWPlayer _player, string _animParameter) : base(_player, _animParameter)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();

        if (player.damageTrigger)
        {
            player.DamageTrigger();
        }
    }


    public override void Update()
    {
        base.Update();
    }
    public virtual void FixedUpdate()
    {

    }
}
