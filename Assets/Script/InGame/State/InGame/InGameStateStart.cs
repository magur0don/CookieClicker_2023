using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameStateStart : InGameState
{

    public InGameStateStart(InGameStateMachine stateMachine, CookieClickerPresenter cookieClickerPresenter) : base(stateMachine, cookieClickerPresenter)
    {
    }

    public override void Enter()
    {
        AudioManager.Instance.PlayBGM(AudioManager.BGMTypes.InGame);
        cookieClickerPresenter.cookieClickerView = cookieClickerPresenter.gameObject.GetComponent<CookieClickerView>();
        cookieClickerPresenter.cookieClickerView.SetClickButtonAction(cookieClickerPresenter.OnClickCookie);
        cookieClickerPresenter.UpdateCookieUI();
        stateMachine.ChangeState(cookieClickerPresenter.InGameStateMain);
    }

    public override void Update()
    {
    }

    public override void Exit()
    {
    }
}
