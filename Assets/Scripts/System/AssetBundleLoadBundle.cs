using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class AssetBundleLoadBundle : AssetBundleLoadOperation
{
    private string bundleName;

    private new AssetBundle asset;
    public new AssetBundle GetAsset() { return asset; }

    public AssetBundleLoadBundle(string bundleName) { this.bundleName = bundleName; }

    public override IEnumerator Load()
    {
        string uri = AssetManager.Instance.GetStreamingAssetsPath(bundleName);
        UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(uri);
 
        yield return request.SendWebRequest();

        asset = DownloadHandlerAssetBundle.GetContent(request);
        AssetManager.Instance.SetLoadedAssetBundle(asset, bundleName);

        loadStatus = AssetBundleLoadStatus.Succeeded;

        yield return null;
    }
}
