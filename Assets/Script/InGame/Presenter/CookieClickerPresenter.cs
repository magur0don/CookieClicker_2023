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

    private async void Start()
    {

        cookieClickerModel = new CookieClickerModel();
        cookieClickerModel.LoadCookieClickCount();

        IEnumerable assetslabel = new object[]
        {
            "CookieImages"
        };

        // ここでUnitaskを使って待つ
        await AddressableAssetLoadUtility.Instance.CheckCatalogUpdates();


        await AddressableAssetLoadUtility.Instance.GetDownloadSize(assetslabel);


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


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            StartCoroutine(AddressableCacheClearUtility.Instance.StartCacheClear());
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
