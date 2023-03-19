using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeButton : MonoBehaviour
{
    public void LoadPage(string assetName)
    {
        EventDispatcher.SendEvent("MENU_EVENT", new EventData("LoadPage", assetName));
    }
}
