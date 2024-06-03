using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WSkillState : PlayerState
{
    public WSkillState(JWPlayer _player, string _animParameter) : base(_player, _animParameter)
    {
    }

    public override void Enter()
    {
        player.anim.SetBool(skillName[1], true);
    }

    public override void Exit()
    {
        player.anim.SetBool(skillName[1], false);
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

        if (Input.GetMouseButton(1))
        {
            player.clickPosition = player.mousePosition;

            player.nav.SetDestination(player.clickPosition);
        }

    }
    public override void FixedUpdate()
    {

    }
}
