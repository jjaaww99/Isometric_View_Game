using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QSkillState : PlayerState
{
    public QSkillState(JWPlayer _player, string _animParameter) : base(_player, _animParameter)
    {
    }

    public override void Enter()
    {
        player.anim.SetBool(skillName[0], true);
    }

    public override void Exit()
    {
        player.anim.SetBool(skillName[0], false);
        player.nav.ResetPath();

        player.clickPosition = player.transform.position;

        player.damageTrigger = false;
        player.effectTrigger = false;
        player.animTrigger = false;
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

    }
}
