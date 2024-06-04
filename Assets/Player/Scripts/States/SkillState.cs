using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillState : PlayerState
{
    public SkillState(JWPlayerController _player, string _animParameter) : base(_player, _animParameter)
    {
    }
    int index;
    public override void Enter()
    {
        base.Enter();

        for (int i = 0; i < player.skillKeyCodes.Length; i++)
        {
            if (Input.GetKey(player.skillKeyCodes[i]))
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

    }
}
