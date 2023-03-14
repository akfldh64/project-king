using System.IO;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
#if UNITY_EDITOR
using UnityEditor;
#endif

[RequireComponent(typeof(AssetLoadOperationHandler))]
public class AssetManager : MonoWeakSingleton<AssetManager>
{
    private AssetLoadOperationHandler operationHanlder;

    private Dictionary<string, AssetBundle> assetBundleDict = new Dictionary<string, AssetBundle>();
    private Dictionary<string, Dictionary<string, UnityEngine.Object>> assetDict = new Dictionary<string, Dictionary<string, UnityEngine.Object>>();

    private void Awake()
    {
        operationHanlder = gameObject.GetComponent<AssetLoadOperationHandler>();
    }

    public void SetLoadedAssetBundle(AssetBundle bundle, string bundleName)
    {
        assetBundleDict[bundleName] = bundle;
    }

    public AssetBundle GetLoadedAssetBundle(string bundleName)
    {
        AssetBundle bundle = null;
        assetBundleDict.TryGetValue(bundleName, out bundle);
        return bundle;
    }

    public void SetLoadedAsset(UnityEngine.Object asset, string bundleName, string assetName)
    {
        Dictionary<string, UnityEngine.Object> tmpDict = null;
        if (assetDict.TryGetValue(bundleName, out tmpDict))
            tmpDict[assetName] = asset;
    }

    public UnityEngine.Object GetLoadedAsset(string bundleName, string assetName)
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

    public AssetBundleLoadOperation LoadAssetBundle(string bundleName)
    {
        var bundle = GetLoadedAssetBundle(bundleName);
        if (bundle != null)
            return new AssetBundleLoadSimulation();

        var operation = new AssetBundleLoadBundle(bundleName);
        operationHanlder.Enqueue(operation);
        return operation;
    }

    public T LoadAsset<T>(string bundleName, string assetName) where T : UnityEngine.Object
    {
        var asset = GetLoadedAsset(bundleName, assetName);
        if (asset != null)
            return asset as T;

#if UNITY_EDITOR
        var bundle = AssetDatabase.LoadMainAssetAtPath(Path.Combine(Application.streamingAssetsPath, bundleName)) as AssetBundle;
#else
        var bundle = GetLoadedAssetBundle(bundleName);
#endif
        if (bundle != null)
            return bundle.LoadAsset(assetName) as T;
        return null;
    }

    public AssetBundleLoadOperation LoadAssetAsync<T>(string bundleName, string assetName) where T : UnityEngine.Object
    {
        var asset = GetLoadedAsset(bundleName, assetName);
        if (asset != null)
            return new AssetBundleLoadAssetSimulation<T>(bundleName, assetName);

#if UNITY_EDITOR
        return new AssetBundleLoadAssetSimulation<T>(bundleName, assetName);
#else
        return new AssetBundleLoadAsset<T>(bundleName, assetName);
#endif
    }

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
