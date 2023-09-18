using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// データ、およびデータの操作はすべてここで行う
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

    public bool LoadedAsset = false;

    /// <summary>
    /// 次のステージへのカウント
    /// </summary>
    public int NextStageCount = 10;

    /// <summary>
    /// ゲームクリア用のカウント
    /// </summary>
    public int GameClearCount = 100;


    public void AddCookieClickCount(int amount)
    {
        cookieClickCount += amount;
        NextStageCount -= amount;
        GameClearCount -= amount;
    }

    public void SaveCookieClickCount()
    {
        var saveData = new PlayerSaveData(string.Empty, cookieClickCount);
        JsonSaveUtility.Save(saveData);
    }

    public void ResetNextStageCount()
    {
        NextStageCount = 10;
    }

    public bool StageClear()
    {
        return NextStageCount == 0;
    }

    public bool GameClear()
    {
        return GameClearCount == 0;
    }

    public void LoadCookieClickCount()
    {
        var loadPlayerData = JsonSaveUtility.Load<PlayerSaveData>();
        // 保存しているデータがある場合
        if (loadPlayerData != null)
        {
            cookieClickCount = loadPlayerData.PlayerScore;
            GameClearCount -= cookieClickCount;

            // cookieClickCountの10割ったあまり。
            NextStageCount = 10 - (cookieClickCount % 10);
            Debug.Log(NextStageCount);
            if (NextStageCount == 0)
            {
                NextStageCount = 10;
            }
            return;
        }
        cookieClickCount = 0;
    }

    public async UniTask LoadCookieImage(int imageNumber)
    {
        var cookieKey = $"CookieImage_{imageNumber}";
        await AddressableAssetLoadUtility.Instance.LoadSpriteAssetAsync(cookieKey);
        cookieImageSprite = AddressableAssetLoadUtility.Instance.ResultSprite;
    }
}
