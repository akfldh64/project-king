using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManageGold : ManageElement
{
    public TextMeshProUGUI wisdomStatText;
    public TextMeshProUGUI expectedReturnText;

    public override void Start()
    {
        wisdomStatText.SetText(collectAmount.ToString());
        expectedReturnText.SetText(collectAmount.ToString());
        collectText.SetText($"{maxCollectCount - collectCount}/{maxCollectCount}");
    }

    public override void AddResource()
    {
        if (collectCount >= maxCollectCount)
            return;

        page.AddGold(collectAmount);
        collectCount++;

        collectText.SetText($"{maxCollectCount - collectCount}/{maxCollectCount}");
    }
}
