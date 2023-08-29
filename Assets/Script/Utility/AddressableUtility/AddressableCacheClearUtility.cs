using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AddressableAssets;


public class AddressableCacheClearUtility : SingletonMonoBehaviour<AddressableCacheClearUtility>
{

    public IEnumerator StartCacheClear()
    {
        var path = $"{Application.persistentDataPath}/com.unity.addressables";
        var files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);

        if (files != null)
        {
            foreach (var file in files)
            {
                File.Delete(file);

            }
        }

        IEnumerable assetslabel = new object[]
        {
            "CookieImages"
        };

        yield return Addressables.ClearDependencyCacheAsync(assetslabel,true);
        yield return Caching.ClearCache();
    }

}
