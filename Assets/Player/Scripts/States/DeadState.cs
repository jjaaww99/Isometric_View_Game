using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class DeadState : PlayerState
{
    public DeadState(JWPlayerController _player, string _animParameter) : base(_player, _animParameter)
    {
    }
    bool isDataSaved = false;
    public override void Enter()
    {
        base.Enter();

        stateTimer = 0;

        isDataSaved = false;

        if (!isDataSaved)
        {
            ScoreManager.instance.OnGameOver();
            isDataSaved = true;
        }
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
