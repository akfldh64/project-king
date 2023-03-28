using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageManager : MonoWeakSingleton<PageManager>
{
    public GameObject LoadPage(string bundleName, string assetName)
    {
        var scene = Instantiate(AssetManager.Instance.LoadAsset<GameObject>(bundleName, assetName));
        scene.gameObject.name = assetName;
        return scene as GameObject;
    }

    public GameObject LoadPage(string bundleName, string assetName, string parentPath)
    {
        var scene = LoadPage(bundleName, assetName);
        scene.transform.SetParent(GameObject.Find(parentPath).transform, false);
        return scene;
    }
}
