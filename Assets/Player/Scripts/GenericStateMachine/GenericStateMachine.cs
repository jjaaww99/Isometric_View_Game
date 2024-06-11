using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericStateMachine<T>
{
    private IState currentState;
    public T user;

    public GenericStateMachine(T _user)
    {
        user = _user;
    }
    
    public void ChangeState(IState _newstate) 
    {
        currentState.Exit();
        currentState = _newstate;
        currentState.Enter();
    }

    public IState GetCurrentState()
    {
        return currentState;
    }
}
