using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleScene : StaticPage
{
    public Button stageBtn;
    public Button closeBtn;

    public void Awake()
    {
        stageBtn.onClick.AddListener(EnterStage);
        closeBtn.onClick.AddListener(Close);
    }

    public void EnterStage()
    {
        var page = Instantiate(AssetManager.Instance.LoadAsset<GameObject>("lobby", "Battle Page"));
        page.gameObject.name = "Battle Page";
        page.transform.SetParent(GameObject.Find("Main Canvas").transform, false);
        BattlePage battlePage = page.GetComponent<BattlePage>();
        {
            battlePage.onClose = (GameObject go) => {
                EventDispatcher.SendEvent("UI_EVENT", new EventData("ShowLobby"));
            };
        }
        EventDispatcher.SendEvent("UI_EVENT", new EventData("HideLobby"));        
    }
}
