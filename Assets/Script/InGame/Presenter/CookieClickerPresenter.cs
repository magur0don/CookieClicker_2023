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


    private void Update()
    {
        if (Keyboard.current.aKey.isPressed)
        {
            Debug.Log("Aキーが押された");
        }
        if (Keyboard.current.enterKey.wasPressedThisFrame)
        {
            Debug.Log("あああ");
            var saveData = new PlayerSaveData(string.Empty, 0);
            JsonSaveUtility.Save(saveData);
            StartCoroutine(AddressableCacheClearUtility.Instance.StartCacheClear());
        }
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
