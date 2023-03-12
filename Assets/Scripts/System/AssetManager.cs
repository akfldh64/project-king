using System.IO;
using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class AssetManager : MonoWeakSingleton<AssetManager>
{
    public void LoadPrefab(string bundleName, string assetName)
    {
        StartCoroutine(LoadPrefabOperation(bundleName, assetName));
    }

    private IEnumerator LoadPrefabOperation(string bundleName, string assetName)
    {
        GameObject asset = null;

#if UNITY_EDITOR
        var assetPaths = AssetDatabase.GetAssetPathsFromAssetBundleAndAssetName(bundleName, assetName);
        if (assetPaths.Length > 0)
            asset = AssetDatabase.LoadMainAssetAtPath(assetPaths[0]) as GameObject;
#else
        string uri = GetStreamingAssetsPath(bundleName);
        UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(uri);

        yield return request.SendWebRequest();

        AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);
        AssetBundleRequest assetRequest = bundle.LoadAssetAsync<GameObject>(assetName);

        yield return assetRequest;

        asset = assetRequest.asset as GameObject;
#endif
        Instantiate(asset);

        yield return null;
    }

    private string GetStreamingAssetsPath(string bundleName)
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
