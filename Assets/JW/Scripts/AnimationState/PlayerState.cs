using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class PlayerState
{
    protected JWPlayer player;
    protected string animName;
    protected StateMachine machine;
    protected Vector3 targetPos;
    protected Vector3 targetDir;
    protected float stateTimer;

    public PlayerState (JWPlayer _player, string _animName)
    {
        player = _player;
        animName = _animName;
        machine = player.stateMachine;
    }

    public virtual void Enter()
    {
        player.anim.SetBool(animName, true);
    }
    public virtual void Exit() 
    {
        player.anim.SetBool(animName, false);

        player.clickPosition = player.transform.position;
    }
    public virtual void Update() 
    {

    }
}
