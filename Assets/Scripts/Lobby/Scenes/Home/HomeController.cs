using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class HomeController : MonoBehaviour
{
    public string pagePath = "Main Canvas/Lobby";

    private string bundleName = "lobby";

    public void LoadPage(string assetName)
    {
        var page = Instantiate(AssetManager.Instance.LoadAsset<GameObject>(bundleName, assetName));
        page.transform.SetParent(GameObject.Find(pagePath).transform, false);
    }
}
