using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class AddressableAssetLoadUtility : SingletonMonoBehaviour<AddressableAssetLoadUtility>
{
    public T LoadAssetAsync<T>(string address) where T : Object
    {
        var assetOperation = Addressables.LoadAssetAsync<T>(address);
        var asset = assetOperation.WaitForCompletion();
        Addressables.Release(assetOperation);
        return asset;
    }
}
