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

    public Button panelButton;
    public Button upgradeButton;

    public TextMeshProUGUI level;
    public TextMeshProUGUI talent;
    public TextMeshProUGUI ability;

    public void Awake()
    {
        panelButton.onClick.AddListener(OpenStatus);
        upgradeButton.onClick.AddListener(UpgradeStatus);

        servantInfo = new ServantInfo(1);   // Dummy Data
        UpdateInfo();
    }

    public void OpenStatus()
    {
        TempGlobalData.Instance.openedServantInfo = servantInfo;

        var page = Instantiate(AssetManager.Instance.LoadAsset<GameObject>("lobby", "Servant Status Page"));
        page.gameObject.name = "Servant Status Page";
        page.transform.SetParent(GameObject.Find("Main Canvas").transform, false);
        page.GetComponent<Page>().onClose = OnCloseStatus;

        EventDispatcher.SendEvent("UI_EVENT", new EventData("HideLobby"));
    }

    public void UpgradeStatus()
    {
        if (servantInfo.level < 10)
        {
            servantInfo.AddExp(servantInfo.GetExpForLevelUp());
            UpdateInfo();
        }
    }

    private void UpdateInfo()
    {
        level.SetText($"Level: {servantInfo.level}");
        talent.SetText($"Talent: {servantInfo.talent}");
        ability.SetText($"Ability: {servantInfo.ability}");
    }

    private void OnCloseStatus(Page page)
    {
        EventDispatcher.SendEvent("UI_EVENT", new EventData("ShowLobby"));

        servantInfo = TempGlobalData.Instance.openedServantInfo;
        TempGlobalData.Instance.openedServantInfo = null;
        UpdateInfo();

        Destroy(page.gameObject);
    }
}
