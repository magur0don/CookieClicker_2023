using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �f�[�^��UI�̒�����s��
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

        // ������Unitask���g���đ҂�
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
    /// �Q�[�����I�����邩�A�V�[�����J�ڂ����Ƃ��ɃZ�[�u���s��
    /// </summary>
    private void OnDestroy()
    {
        cookieClickerModel.SaveCookieClickCount();
    }
}
