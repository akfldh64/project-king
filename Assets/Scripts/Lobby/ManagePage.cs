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

    public void Awake()
    {
        foreach (var element in elements)
            element.SetPage(this);
    }

    private long goldAmount;
    private long foodAmount;
    private long soldierAmount;

    public void AddGold(long amount)
    {
        goldAmount += amount;
        goldText.SetText(goldAmount.ToString());
    }

    public void AddFood(long amount)
    {
        foodAmount += amount;
        foodText.SetText(foodAmount.ToString());
    }

    public void AddSoldier(long amount)
    {
        soldierAmount += amount;
        soldierText.SetText(soldierAmount.ToString());
    }

    protected override void OnClose()
    {
        caller.SendMessage("Closed", this.gameObject);
    }
}
