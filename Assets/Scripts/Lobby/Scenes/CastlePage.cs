using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastlePage : StaticPage
{
    public void LoadManagePage()
    {
        var page = Instantiate(AssetManager.Instance.LoadAsset<GameObject>("lobby", "Manage Page"));
        page.gameObject.name = "Manage Page";
        page.transform.SetParent(GameObject.Find("Main Canvas/Lobby").transform, false);
        page.GetComponent<Page>().onClose = (GameObject go) => {
            EventDispatcher.SendEvent("UI_EVENT", new EventData("ShowUI"));
        };

        EventDispatcher.SendEvent("UI_EVENT", new EventData("HideUI"));
    }
}
