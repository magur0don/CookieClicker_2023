using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;
using Cysharp.Threading.Tasks;

public class AddressableAssetLoadUtility : SingletonMonoBehaviour<AddressableAssetLoadUtility>
{
    private AsyncOperationHandle assetOperation = new AsyncOperationHandle();

    private AsyncOperationHandle<long> getDownloadSize = new AsyncOperationHandle<long>();

    private AsyncOperationHandle<List<string>> checkCatalog = new AsyncOperationHandle<List<string>>();

    private AsyncOperationHandle<List<IResourceLocator>> updateCatalog = new AsyncOperationHandle<List<IResourceLocator>>();

    private AsyncOperationHandle<IResourceLocator> initializeResourceLocator = new AsyncOperationHandle<IResourceLocator>();

    public T LoadAssetAsync<T>(string address) where T : Object
    {
        assetOperation = Addressables.LoadAssetAsync<T>(address);
        var asset = assetOperation.WaitForCompletion();
        return (T)asset;
    }
    public async UniTask GetDownloadSize(IEnumerable addressLabel)
    {
        getDownloadSize = Addressables.GetDownloadSizeAsync(addressLabel);
        await getDownloadSize;
        if (getDownloadSize.IsValid() && getDownloadSize.Result > 0)
        {
            Debug.Log(getDownloadSize.Result);
        }
    }

    public async UniTask CheckCatalogUpdates()
    {
        var catalogToUpdate = new List<string>();
        checkCatalog = Addressables.CheckForCatalogUpdates();
        await checkCatalog;
        if (checkCatalog.IsValid() && checkCatalog.Result.Count > 0)
        {
            catalogToUpdate.AddRange(checkCatalog.Result);
        }
        if (catalogToUpdate.Count > 0)
        {
            Debug.Log("カタログが更新されました");
            updateCatalog = Addressables.UpdateCatalogs(catalogToUpdate);
            if (updateCatalog.IsValid())
            {
                await updateCatalog;

            }
        }
        else
        {
            if (initializeResourceLocator.IsValid())
            {
                await initializeResourceLocator;
            }
        }
    }

    public IEnumerator CheckCatalogUpdatesCoroutine()
    {
        var catalogToUpdate = new List<string>();
        checkCatalog = Addressables.CheckForCatalogUpdates();
        yield return checkCatalog;
        if (checkCatalog.IsValid() && checkCatalog.Result.Count > 0)
        {
            catalogToUpdate.AddRange(checkCatalog.Result);
        }
        if (catalogToUpdate.Count > 0)
        {
            Debug.Log("カタログが更新されました");
            updateCatalog = Addressables.UpdateCatalogs(catalogToUpdate);
            yield return updateCatalog;
        }
        else
        {
            yield return initializeResourceLocator;
        }
    }

    private void OnDestroy()
    {
        if (assetOperation.IsValid())
        {
            Addressables.Release(assetOperation);
        }
        if (getDownloadSize.IsValid())
        {
            Addressables.Release(getDownloadSize);
        }
        if (checkCatalog.IsValid())
        {
            Addressables.Release(checkCatalog);
        }
        if (updateCatalog.IsValid())
        {
            Addressables.Release(updateCatalog);
        }
        if (initializeResourceLocator.IsValid())
        {
            Addressables.Release(initializeResourceLocator);
        }
    }
}
