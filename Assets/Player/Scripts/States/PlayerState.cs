using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Timers;
using UnityEngine;

public class PlayerState
{
    protected JWPlayerController player;
    protected MonsterStateManager enemy;
    protected string animParameter;
    protected StateMachine machine;
    protected Vector3 targetPos;
    protected Vector3 targetDir;
    protected float stateTimer;

    public PlayerState (JWPlayerController _player, string _animParameter)
    {
        player = _player;
        animParameter = _animParameter;
        machine = player.stateMachine;
    }

    public virtual void Enter()
    {
        player.animator.SetBool(animParameter, true);
        player.damageTrigger = false;
        player.effectTrigger = false;
        player.animTrigger = false;
    }
    public virtual void Exit() 
    {
        player.animator.SetBool(animParameter, false);

        player.nav.ResetPath();

        player.targetPosition = player.transform.position;
    }
    public virtual void Update() 
    {

    }
    public virtual void FixedUpdate()
    {

    }
}
