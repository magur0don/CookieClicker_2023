using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// データとUIの仲介を行う
/// </summary>
public class CookieClickerPresenter : MonoBehaviour
{

    internal CookieClickerModel cookieClickerModel;
    internal CookieClickerView cookieClickerView;

    private InGameStateMachine stateMachine;

    public InGameStateMachine GetMainGameState
    {
        get { return stateMachine; }
    }

    public InGameStateInit InGameStateInit;
    public InGameStateStart InGameStateStart;

    // MainGame部分
    public InGameStateMain InGameStateMain;

    // ゲームリザルト
    public InGameStateResult InGameStateResult;
    public InGameStateEnd InGameStateEnd;

    private void Start()
    {
        stateMachine = new InGameStateMachine();

        InGameStateInit = new InGameStateInit(stateMachine, this);
        InGameStateStart = new InGameStateStart(stateMachine, this);

        InGameStateMain = new InGameStateMain(stateMachine, this);

        InGameStateResult = new InGameStateResult(stateMachine, this);
        InGameStateEnd = new InGameStateEnd(stateMachine, this);

        // Initからスタートする
        stateMachine.ChangeState(InGameStateInit);

    }

    public void OnClickCookie()
    {
        cookieClickerModel.AddCookieClickCount(1);
        UpdateCookieUI();
    }

    public void UpdateCookieUI()
    {
        cookieClickerView.UpdateCookieCount(cookieClickerModel.GetcookieClickCount());
    }

    public bool NextStage() {

        return 0 == cookieClickerModel.GetcookieClickCount();
    }

    private void Update()
    {
        if (stateMachine != null)
        {
            stateMachine.Update();
        }
    }

    /// <summary>
    /// ゲームが終了するか、シーンが遷移したときにセーブを行う
    /// </summary>
    private void OnDestroy()
    {
        cookieClickerModel.SaveCookieClickCount();
    }
}
