using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public static class Value
{
    public static List<long> expTable = new List<long>{ 5, 10, 50, 100, 400, 500, 1000, 2000, 4000, 6000 };
    public static List<long> abilityTable = new List<long>{ 100, 200, 300, 500, 1000, 2000, 4000, 7000, 12000, 20000 };
}

public class ServantInfo
{
    public int level;
    public long nextExp;
    public long ability;
    public long talent = 10; // Dummy

    public long currentExp;

    public ServantInfo(int level)
    {
        this.level = level;
        this.nextExp = Value.expTable[level - 1];
        this.ability = Value.abilityTable[level - 1];
        this.currentExp = 0;
    }

    public void AddExp(long exp)
    {
        currentExp += exp;
        if (currentExp >= nextExp)
        {
            level++;
            currentExp = currentExp - nextExp;
            nextExp = Value.expTable[level - 1];
            ability = Value.abilityTable[level - 1];
        }
    }

    public long GetExpForLevelUp()
    {
        return nextExp - currentExp;
    }
}

public class ServantElement : MonoBehaviour
{
    private ServantInfo servantInfo;

    public Button upgradeButton;
    public Button panelButton;

    public TextMeshProUGUI level;
    public TextMeshProUGUI talent;
    public TextMeshProUGUI ability;

    public void Awake()
    {
        upgradeButton.onClick.AddListener(Upgrade);
        panelButton.onClick.AddListener(OpenStatusPage);

        servantInfo = new ServantInfo(1);   // Dummy data
        UpdateInfo();
    }

    public void Upgrade()
    {
        if (servantInfo.level < 10)
        {
            servantInfo.AddExp(servantInfo.GetExpForLevelUp());
            UpdateInfo();
        }
    }

    // TODO: move to parent
    public void OpenStatusPage()
    {
        var page = Instantiate(AssetManager.Instance.LoadAsset<GameObject>("lobby", "Servant Status Page"));
        page.gameObject.name = "Servant Status Page";
        page.transform.SetParent(GameObject.Find("Main Canvas").transform, false);
        ServantStatusPage servantPage = page.GetComponent<ServantStatusPage>();
        {
            servantPage.servantInfo = this.servantInfo;
            servantPage.onClose = (GameObject go) => {
                this.servantInfo = servantPage.servantInfo;
                UpdateInfo();
 
                EventDispatcher.SendEvent("UI_EVENT", new EventData("ShowLobby"));
            };
        }
        EventDispatcher.SendEvent("UI_EVENT", new EventData("HideLobby"));
    }

    private void UpdateInfo()
    {
        level.SetText($"Level: {servantInfo.level}");
        talent.SetText($"Talent: {servantInfo.talent}");
        ability.SetText($"Ability: {servantInfo.ability}");
    }
}
