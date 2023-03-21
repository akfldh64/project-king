using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageGold : ManageElement
{
    public override void AddResource()
    {
        if (collectCount >= maxCollectCount)
            return;

        page.AddGold(collectAmount);
        collectCount++;
    }
}
