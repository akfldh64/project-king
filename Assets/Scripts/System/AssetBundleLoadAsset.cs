using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class AssetBundleLoadAsset : AssetBundleLoadOperation
{
    private string bundleName;
    private string assetName;

    public AssetBundleLoadAsset(string bundleName, string assetName) { this.bundleName = bundleName; this.assetName = assetName; }

    public void Load<T>()
    {
        StartCoroutine(LoadAsset<T>(bundleName, assetName));
    }

    private IEnumerator LoadAsset<T>(string bundleName, string assetName)
    {
#if UNITY_EDITOR
        var assetPaths = AssetDatabase.GetAssetPathsFromAssetBundleAndAssetName(bundleName, assetName);
        if (assetPaths.Length > 0)
        {
            asset = AssetDatabase.LoadMainAssetAtPath(assetPaths[0]) as GameObject;        
            AssetManager.Instance.AddAsset(asset, bundleName, assetName);

            loadStatus = AssetBundleLoadStatus.Succeeded;
        }
        else
        {
            loadStatus = AssetBundleLoadStatus.Failed;
        }

        yield return null;
#else
        var bundle = AssetManager.Instance.GetAssetBundle(bundleName);
        if (bundle != null)
        {
            AssetBundleRequest assetRequest = bundle.LoadAssetAsync<T>(assetName);

            yield return assetRequest;

            asset = assetRequest.asset as GameObject;
            AssetManager.Instance.AddAsset(asset, bundleName, assetName);

            loadStatus = AssetBundleLoadStatus.Succeeded;

            yield return null;
        }
        loadStatus = AssetBundleLoadStatus.Failed;

        yield return null;
#endif
    }
}
