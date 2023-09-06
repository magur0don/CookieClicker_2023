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
        // �Q�[�����N���A������GamewEnd��
        if (cookieClickerPresenter.cookieClickerModel.GameClear())
        {
            stateMachine.ChangeState(cookieClickerPresenter.InGameStateEnd);
        }
        else
        {
            // �Q�[���N���A�ɂȂ�Ȃ������ꍇ��GameMain�֖߂�
            Debug.Log("�N���A�ɂȂ�Ȃ������ꍇ");
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
