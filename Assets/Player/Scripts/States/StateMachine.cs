using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine 
{
    public PlayerState currentState;

    public void Init(PlayerState startState)
    {
        currentState = startState;
        startState.Enter();
    }

    public void ChangeState(PlayerState targetState)
    {
        currentState.Exit();
        currentState = targetState;
        targetState.Enter();
    }

    public PlayerState GetState()
    {
        return currentState;
    }
}
