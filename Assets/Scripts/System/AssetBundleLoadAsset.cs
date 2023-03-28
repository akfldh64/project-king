using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class AssetBundleLoadAsset<T> : AssetBundleLoadOperation where T : UnityEngine.Object
{
    private string bundleName;
    private string assetName;
    public AssetBundleLoadAsset(string bundleName, string assetName)
    {
        this.bundleName = bundleName;
        this.assetName = assetName;
    }

    public new T GetAsset() => asset as T;

    public override IEnumerator Load()
    {
        var bundle = AssetManager.Instance.GetLoadedAssetBundle(bundleName);
        if (bundle != null)
        {
            AssetBundleRequest assetRequest = bundle.LoadAssetAsync<T>(assetName);

            yield return assetRequest;

            asset = assetRequest.asset as T;
            AssetManager.Instance.SetLoadedAsset(asset, bundleName, assetName);

            loadStatus = AssetBundleLoadStatus.Succeeded;
        }
        yield return null;
    }
}
public class AssetBundleLoadAssetSimulation<T> : AssetBundleLoadOperation where T : UnityEngine.Object
{
    private void LoadAsset(string bundleName, string assetName)
    {
#if UNITY_EDITOR
        var assetPaths = AssetDatabase.GetAssetPathsFromAssetBundleAndAssetName(bundleName, assetName);
        if (assetPaths.Length > 0)
        {
            asset = AssetDatabase.LoadMainAssetAtPath(assetPaths[0]) as T;
            AssetManager.Instance.SetLoadedAsset(asset, bundleName, assetName);
        }
#endif
        loadStatus = AssetBundleLoadStatus.Succeeded;
    }

    public AssetBundleLoadAssetSimulation(string bundleName, string assetName) { LoadAsset(bundleName, assetName); }
    public new T GetAsset() => asset as T;
}
