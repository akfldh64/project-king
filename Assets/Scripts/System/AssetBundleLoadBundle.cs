using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class AssetBundleLoadBundle : AssetBundleLoadOperation
{
    private string bundleName;

    protected new AssetBundle asset;
    public new AssetBundle GetAsset() { return asset; }

    public AssetBundleLoadBundle(string bundleName) { this.bundleName = bundleName; }

    public void Load()
    {
        StartCoroutine(LoadBundle(bundleName));
    }

    private IEnumerator LoadBundle(string bundleName)
    {
        string uri = AssetManager.Instance.GetStreamingAssetsPath(bundleName);
        UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(uri);
 
        yield return request.SendWebRequest();

        asset = DownloadHandlerAssetBundle.GetContent(request);
        AssetManager.Instance.AddAssetBundle(asset, bundleName);

        loadStatus = AssetBundleLoadStatus.Succeeded;

        yield return null;
    }
}
