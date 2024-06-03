using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class PlayerState
{
    protected JWPlayer player;
    protected MonsterStateManager enemy;
    protected string animParameter;
    protected StateMachine machine;
    protected Vector3 targetPos;
    protected Vector3 targetDir;
    protected float stateTimer;

    public PlayerState (JWPlayer _player, string _animParameter)
    {
        player = _player;
        animParameter = _animParameter;
        machine = player.machine;
    }

    public virtual void Enter()
    {
        player.anim.SetBool(animParameter, true);
    }
    public virtual void Exit() 
    {
        player.anim.SetBool(animParameter, false);

        player.nav.ResetPath();

        player.clickPosition = player.transform.position;

    }
    public virtual void Update() 
    {

    }
}
