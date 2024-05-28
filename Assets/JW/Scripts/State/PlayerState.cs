using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    public JWPlayer player;
    public string animName;
    public StateMachine machine;
    public PlayerState (JWPlayer _player, string _animName)
    {
        player = _player;
        animName = _animName;
        machine = player.stateMachine;
    }

    Animator animator;
    public virtual void Enter()
    {
        player.anim.SetBool(animName, true);
    }
    public virtual void Exit() 
    {
        player.anim.SetBool(animName, false);
    }
    public virtual void Update() 
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {

        }

    }
}
