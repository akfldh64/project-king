using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManagePage : Page
{
    public List<ManageElement> elements;

    public TextMeshProUGUI goldText;
    public TextMeshProUGUI foodText;
    public TextMeshProUGUI soldierText;

    private UserInfo userInfo;

    public void Awake()
    {
        foreach (var element in elements)
            element.SetPage(this);
    }

    public void Start()
    {
        userInfo = TempGlobalData.Instance.me;

        goldText.SetText($"{userInfo.funding}");
        foodText.SetText($"{userInfo.supplies}");
        soldierText.SetText($"{userInfo.army}");
    }

    public void AddGold(long amount)
    {
        userInfo.funding += amount;
        goldText.SetText(userInfo.funding.ToString());
    }

    public void AddFood(long amount)
    {
        userInfo.supplies += amount;
        foodText.SetText(userInfo.supplies.ToString());
    }

    public void AddSoldier(long amount)
    {
        userInfo.army += amount;
        soldierText.SetText(userInfo.army.ToString());
    }
}
