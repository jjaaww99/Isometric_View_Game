using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : PlayerState
{
    public DeadState(JWPlayerController _player, string _animParameter) : base(_player, _animParameter)
    {
    }

    public override void Enter()
    {
        base.Enter();
        GameManager.instance.gameState = GameState.Idle;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
    }
}
