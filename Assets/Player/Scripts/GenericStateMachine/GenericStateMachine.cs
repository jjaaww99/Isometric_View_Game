using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GenericStateMachine
{
    public IState currentState;
    public StateMachineAvatar stateMachineAvatar;

    public Idle idle;
    public Evade evade;
    public Attack attack;
    
    public GenericStateMachine(StateMachineAvatar _stateMachineAvatar)
    {
        stateMachineAvatar = _stateMachineAvatar;

        idle = new Idle(stateMachineAvatar, "Idle");
        attack = new Attack(stateMachineAvatar, "Attack");
    }

    public void PlayerPackage()
    {
        evade = new Evade(stateMachineAvatar, "Evade");
    }

    public void MonsterPackage()
    {

    }

    public void Initialize(IState _startState)
    {
        currentState = _startState;
        currentState.Enter();
    }

    public void ChangeState(IState _newstate) 
    {
        currentState.Exit();
        currentState = _newstate;
        currentState.Enter();
    }

    public void Update()
    {
        currentState.Update();
    }

    public IState GetCurrentState()
    {
        return currentState;
    }
}