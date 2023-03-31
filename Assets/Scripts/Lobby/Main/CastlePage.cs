using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastlePage : Page
{
    public void LoadManagePage()
    {
        var page = Instantiate(AssetManager.Instance.LoadAsset<GameObject>("lobby", "Manage Page"));
        page.gameObject.name = "Manage Page";
        page.transform.SetParent(GameObject.Find("Main Canvas/Lobby").transform, false);
        page.GetComponent<Page>().onClose = OnClosePage;

        EventDispatcher.SendEvent("UI_EVENT", new EventData("HideUI"));
    }

    private void OnClosePage(Page page)
    {
        Destroy(page.gameObject);

        EventDispatcher.SendEvent("UI_EVENT", new EventData("ShowUI"));
    }
}
