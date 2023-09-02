using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameStateMachine
{
    private InGameState currentState;

    public InGameState GetInGameState
    {
        get { return currentState; }
    }

    public bool IsState(InGameState state)
    {
        return GetInGameState == state;
    }

    public void ChangeState(InGameState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;
        currentState.Enter();
    }

    public void Update()
    {
        if (currentState != null)
        {
            currentState.Update();
        }
    }
}
