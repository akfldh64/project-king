using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class LoadAsset : MonoBehaviour
{
    public string parentPath = "Main Canvas/Lobby";
    public string bundleName = "lobby";

    public void Load(string assetName)
    {
        var asset = Instantiate(AssetManager.Instance.LoadAsset<GameObject>(bundleName, assetName));
        asset.transform.SetParent(GameObject.Find(parentPath).transform, false);
    }
}
