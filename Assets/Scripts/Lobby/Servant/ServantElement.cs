using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServantElement : MonoBehaviour
{
    public Button panelButton;
    public Button upgradeButton;

    public void Awake()
    {
        panelButton.onClick.AddListener(OpenStatus);
        upgradeButton.onClick.AddListener(UpgradeStatus);
    }

    public void OpenStatus()
    {
        var page = Instantiate(AssetManager.Instance.LoadAsset<GameObject>("lobby", "Servant Status Page"));
        page.gameObject.name = "Servant Status Page";
        page.transform.SetParent(GameObject.Find("Main Canvas").transform, false);
        page.GetComponent<Page>().onClose = OnCloseStatus;

        EventDispatcher.SendEvent("UI_EVENT", new EventData("HideLobby"));
    }

    private void OnCloseStatus(Page page)
    {
        Destroy(page.gameObject);

        EventDispatcher.SendEvent("UI_EVENT", new EventData("ShowLobby"));
    }

    public void UpgradeStatus()
    {
        Debug.Log("Upgrade");
    }
}
