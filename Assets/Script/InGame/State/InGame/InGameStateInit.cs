using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameStateInit : InGameState
{
    public InGameStateInit(InGameStateMachine stateMachine
         , CookieClickerPresenter cookieClickerPresenter) : base(stateMachine, cookieClickerPresenter)
    {
    }

    public override void Enter()
    {
        
        cookieClickerPresenter.cookieClickerModel = new CookieClickerModel();
        cookieClickerPresenter.cookieClickerModel.LoadCookieClickCount();
        stateMachine.ChangeState(cookieClickerPresenter.InGameStateStart);
    }

    public override void Update()
    {
    }

    public override void Exit()
    {
    }
}
