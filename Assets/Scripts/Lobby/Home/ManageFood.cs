using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManageFood : ManageElement
{
    public TextMeshProUGUI politicsStatText;
    public TextMeshProUGUI expectedReturnText;

    public override void Start()
    {
        politicsStatText.SetText(collectAmount.ToString());
        expectedReturnText.SetText(collectAmount.ToString());
        collectText.SetText($"{maxCollectCount - collectCount}/{maxCollectCount}");
    }

    public override void AddResource()
    {
        if (collectCount >= maxCollectCount)
            return;

        page.AddFood(collectAmount);
        collectCount++;

        collectText.SetText($"{maxCollectCount - collectCount}/{maxCollectCount}");
    }
}
