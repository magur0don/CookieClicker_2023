using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameStateResult : InGameState
{
    public InGameStateResult(InGameStateMachine stateMachine, CookieClickerPresenter cookieClickerPresenter) : base(stateMachine, cookieClickerPresenter)
    {
    }

    public override void Enter()
    {
        // ゲームをクリアしたらGamewEndへ
        if (cookieClickerPresenter.cookieClickerModel.GameClear())
        {
            stateMachine.ChangeState(cookieClickerPresenter.InGameStateEnd);
        }
        else
        {
            // ゲームクリアにならなかった場合はGameMainへ戻る
            Debug.Log("クリアにならなかった場合");
            cookieClickerPresenter.cookieClickerModel.ResetNextStageCount();
            stateMachine.ChangeState(cookieClickerPresenter.InGameStateMain);
        }
    }

    public override void Update()
    {
    }

    public override void Exit()
    {
    }
}
