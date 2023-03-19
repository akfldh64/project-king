using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class LoadAssetAtLobby : MonoBehaviour
{
    private string parentPath = "Main Canvas/Lobby";
    private string bundleName = "lobby";

    public void LoadAsset(string assetName)
    {
        var asset = Instantiate(AssetManager.Instance.LoadAsset<GameObject>(bundleName, assetName));
        asset.transform.SetParent(GameObject.Find(parentPath).transform, false);
    }
}
