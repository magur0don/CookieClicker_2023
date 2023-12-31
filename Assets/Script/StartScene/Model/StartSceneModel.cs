using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneModel
{
    private bool LoadedAsset = false;
    public async UniTask Load()
    {
        LoadedAsset = false;
        IEnumerable assetslabel = new object[]
        {
            "CookieImages",
            "BGM",
            "SE",
        };
        // ここでUnitaskを使って待つ
        await AddressableAssetLoadUtility.Instance.CheckCatalogUpdates();
        await AddressableAssetLoadUtility.Instance.GetDownloadSize(assetslabel);
        LoadedAsset = true;
    }

}
