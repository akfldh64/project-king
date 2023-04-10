using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeScene : StaticPage
{
    public Button managerBtn;
    public Button staffBtn;
    public Button wifeBtn;

    public void OnEnable()
    {
        managerBtn.onClick.AddListener(OpenManagerPage);
        staffBtn.onClick.AddListener(OpenStaffPage);
        wifeBtn.onClick.AddListener(OpenWifePage);
    }

    public void OnDisable()
    {
        managerBtn.onClick.RemoveListener(OpenManagerPage);
        staffBtn.onClick.RemoveListener(OpenStaffPage);
        wifeBtn.onClick.RemoveListener(OpenWifePage);
    }

    public void OpenManagerPage()
    {
        OpenPage("lobby", "Management Page");
    }

    public void OpenStaffPage()
    {
        OpenPage("lobby", "Political Page");
    }

    public void OpenWifePage()
    {
        OpenPage("lobby", "Wives Page");
    }

    public void OpenPage(string bundleName, string assetName)
    {
        var page = Instantiate(AssetManager.Instance.LoadAsset<GameObject>(bundleName, assetName));
        page.gameObject.name = assetName;
        page.transform.SetParent(GameObject.Find("Main Canvas").transform, false);
        page.GetComponent<Page>().onClose = (GameObject go) => {
            EventDispatcher.SendEvent("UI_EVENT", new EventData("ShowLobby"));
        };

        EventDispatcher.SendEvent("UI_EVENT", new EventData("HideLobby"));        
    }
}
