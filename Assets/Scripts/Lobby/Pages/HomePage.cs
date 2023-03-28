using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomePage : Page
{
    private void OnClose(Page page)
    {
        Destroy(page.gameObject);
        EventDispatcher.SendEvent("UI_EVENT", new EventData("ShowUI"));
    }

    public void LoadManagePage()
    {
        var page = PageManager.Instance.LoadPage("lobby", "Manage Page", "Main Canvas/Lobby");
        page.GetComponent<Page>().onClose = OnClose;

        EventDispatcher.SendEvent("UI_EVENT", new EventData("HideUI"));
    }
}
