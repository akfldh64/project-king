using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManageSoldier : ManageElement
{
    public TextMeshProUGUI charmStatText;
    public TextMeshProUGUI expectedReturnText;
    public TextMeshProUGUI usedFoodText;

    public override void Start()
    {
        charmStatText.SetText(collectAmount.ToString());
        expectedReturnText.SetText(collectAmount.ToString());
        usedFoodText.SetText(collectAmount.ToString());
        collectText.SetText($"{maxCollectCount - collectCount}/{maxCollectCount}");
    }

    public override void AddResource()
    {
        if (collectCount >= maxCollectCount)
            return;

        page.AddSoldier(collectAmount);
        collectCount++;

        collectText.SetText($"{maxCollectCount - collectCount}/{maxCollectCount}");
    }
}
