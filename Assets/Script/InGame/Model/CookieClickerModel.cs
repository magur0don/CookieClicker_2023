using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// �f�[�^�A����уf�[�^�̑���͂��ׂĂ����ōs��
/// </summary>
public class CookieClickerModel
{
    private int cookieClickCount;
    public int GetcookieClickCount()
    {
        return cookieClickCount;
    }
    [SerializeField]
    private Sprite cookieImageSprite;

    public Sprite GetCookieImageSprite
    {
        get
        {
            return cookieImageSprite;
        }
    }

    public void AddCookieClickCount(int amount)
    {
        cookieClickCount += amount;
    }

    public void SaveCookieClickCount()
    {
        var saveData = new PlayerSaveData(string.Empty, cookieClickCount);
        JsonSaveUtility.Save(saveData);
    }

    public void LoadCookieClickCount()
    {
        var loadPlayerData = JsonSaveUtility.Load<PlayerSaveData>();
        // �ۑ����Ă���f�[�^������ꍇ
        if (loadPlayerData != null)
        {
            cookieClickCount = loadPlayerData.PlayerScore;
            return;
        }
        cookieClickCount = 0;
    }

    public void LoadCookieImage()
    {
        var cookieSprite = AddressableAssetLoadUtility.Instance.LoadAssetAsync<Sprite>("CookieImage_0");
        cookieImageSprite = cookieSprite;
    }


}
