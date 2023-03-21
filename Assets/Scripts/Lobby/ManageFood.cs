using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageFood : ManageElement
{
    public override void AddResource()
    {
        if (collectCount >= maxCollectCount)
            return;

        page.AddFood(collectAmount);
        collectCount++;
    }
}
