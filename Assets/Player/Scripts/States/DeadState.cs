using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class DeadState : PlayerState
{
    public DeadState(JWPlayerController _player, string _animParameter) : base(_player, _animParameter)
    {
    }

    public override void Enter()
    {
        base.Enter();

        ScoreManager.instance.OnGameOver();

        stateTimer = 0;
    }

    public override void Exit()
    {
        base.Exit();

    }

    public override void Update()
    {
        base.Update();
      
        stateTimer += Time.deltaTime;

        if(stateTimer > 3 ) 
        {
            SceneController.Instance.ToStartScene();
        }
    }
}
