using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameStateInit : InGameState
{
    public InGameStateInit(InGameStateMachine stateMachine
         , CookieClickerPresenter cookieClickerPresenter) : base(stateMachine, cookieClickerPresenter)
    {
    }

    public override async void Enter()
    {
        AudioManager.Instance.AudioLoad();
        cookieClickerPresenter.cookieClickerModel = new CookieClickerModel();
        cookieClickerPresenter.cookieClickerModel.LoadCookieClickCount();
        await cookieClickerPresenter.cookieClickerModel.Load();
    }

    public override void Update()
    {
        if (cookieClickerPresenter.cookieClickerModel.LoadedAsset)
        {
            stateMachine.ChangeState(cookieClickerPresenter.InGameStateStart);
        }
    }

    public override void Exit()
    {
    }
}
