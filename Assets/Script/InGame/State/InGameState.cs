using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameState : MonoBehaviour
{
    protected InGameStateMachine stateMachine;

    public InGameState(InGameStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }
    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void Update() { }
}
