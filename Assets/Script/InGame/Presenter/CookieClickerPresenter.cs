using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// データとUIの仲介を行う
/// </summary>
public class CookieClickerPresenter : MonoBehaviour
{

    private CookieClickerModel cookieClickerModel;
    private CookieClickerView cookieClickerView;

    private void Start()
    {

        cookieClickerModel = new CookieClickerModel();
        cookieClickerModel.LoadCookieClickCount();
        cookieClickerModel.LoadCookieImage();

        cookieClickerView = GetComponent<CookieClickerView>();

        cookieClickerView.SetClickButtonAction(OnClickCookie);
        cookieClickerView.SetButtonImage(cookieClickerModel.GetCookieImageSprite);
        UpdateCookieUI();
    }

    private void OnClickCookie()
    {
        cookieClickerModel.AddCookieClickCount(1);
        UpdateCookieUI();
    }

    private void UpdateCookieUI()
    {
        cookieClickerView.UpdateCookieCount(cookieClickerModel.GetcookieClickCount());
    }

    /// <summary>
    /// ゲームが終了するか、シーンが遷移したときにセーブを行う
    /// </summary>
    private void OnDestroy()
    {
        cookieClickerModel.SaveCookieClickCount();
    }
}
