using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageSoldier : ManageElement
{
    public override void AddResource()
    {
        if (collectCount >= maxCollectCount)
            return;

        page.AddSoldier(collectAmount);
        collectCount++;
    }
}
