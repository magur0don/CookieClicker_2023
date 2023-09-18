using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameStateMain : InGameState
{
    public InGameStateMain(InGameStateMachine stateMachine,
             CookieClickerPresenter cookieClickerPresenter) : base(stateMachine, cookieClickerPresenter)
    {
    }

    public override async void Enter()
    {
        var randomCookieNumber = Random.Range(0,10);
        await cookieClickerPresenter.cookieClickerModel.LoadCookieImage(randomCookieNumber);
        cookieClickerPresenter.cookieClickerView.SetButtonImage(cookieClickerPresenter.cookieClickerModel.GetCookieImageSprite);
    }

    public override void Update()
    {
        if (cookieClickerPresenter.cookieClickerModel.StageClear())
        {
            Debug.Log("ステージクリア");
            stateMachine.ChangeState(cookieClickerPresenter.InGameStateResult);
        }
    }

    public override void Exit()
    {
    }
}
