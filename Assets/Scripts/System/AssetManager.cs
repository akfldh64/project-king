using System.IO;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class AssetManager : MonoWeakSingleton<AssetManager>
{
    private Dictionary<string, AssetBundle> assetBundleDict = new Dictionary<string, AssetBundle>();
    private Dictionary<string, Dictionary<string, UnityEngine.Object>> assetDict = new Dictionary<string, Dictionary<string, UnityEngine.Object>>();

    public void AddAssetBundle(AssetBundle bundle, string bundleName)
    {
        assetBundleDict[bundleName] = bundle;
    }

    public AssetBundle GetAssetBundle(string bundleName)
    {
        AssetBundle bundle = null;
        assetBundleDict.TryGetValue(bundleName, out bundle);
        return bundle;
    }

    public void AddAsset(UnityEngine.Object asset, string bundleName, string assetName)
    {
        assetDict[bundleName][assetName] = asset;
    }

    public T GetAsset<T>(string bundleName, string assetName) where T : UnityEngine.Object
    {
        return GetAsset(bundleName, assetName) as T;
    }

    public UnityEngine.Object GetAsset(string bundleName, string assetName)
    {
        Dictionary<string, UnityEngine.Object> tmpDict = null;
        if (assetDict.TryGetValue(bundleName, out tmpDict))
        {
            UnityEngine.Object asset = null;
            if (tmpDict.TryGetValue(assetName, out asset))
                return asset;
        }
        return null;
    }

    // TODO: Simulation
    public AssetBundleLoadOperation LoadAssetBundle(string bundleName)
    {
        var bundle = GetAssetBundle(bundleName);
        if (bundle != null)
            return new AssetBundleLoadBundle(bundleName);
        return new AssetBundleLoadBundle(bundleName);
    }

    public AssetBundleLoadOperation LoadAsset(string bundleName, string assetName)
    {
        var bundle = GetAssetBundle(bundleName);
        if (bundle != null)
            return new AssetBundleLoadBundle(bundleName);
        return new AssetBundleLoadBundle(bundleName);
    }

//     private IEnumerator LoadAssetbOperation(string bundleName, string assetName)
//     {
//         GameObject asset = null;

// #if UNITY_EDITOR
//         var assetPaths = AssetDatabase.GetAssetPathsFromAssetBundleAndAssetName(bundleName, assetName);
//         if (assetPaths.Length > 0)
//             asset = AssetDatabase.LoadMainAssetAtPath(assetPaths[0]) as GameObject;
// #else
//         string uri = GetStreamingAssetsPath(bundleName);
//         UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(uri);

//         yield return request.SendWebRequest();

//         AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);
//         AssetBundleRequest assetRequest = bundle.LoadAssetAsync<GameObject>(assetName);

//         yield return assetRequest;

//         asset = assetRequest.asset as GameObject;
// #endif
//         Instantiate(asset);

//         yield return null;
//     }

    public string GetStreamingAssetsPath(string bundleName)
    {
#if UNITY_WEBGL
        return Path.Combine(Application.streamingAssetsPath, bundleName);
#elif UNITY_ANDROID
        return Path.Combine(Application.streamingAssetsPath, bundleName + ".assetbundle");
#else
        return "file://" + Path.Combine(Application.streamingAssetsPath, bundleName);
#endif
    }
}
