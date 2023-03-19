using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSendEvent : MonoBehaviour
{
    const string UIEventType = "UI_EVENT";
    const string ContentEventType = "CONTENT_EVENT";

    public void SendUIEvent(string eventName)
    {
        EventDispatcher.SendEvent(UIEventType, new EventData(eventName));
    }

    public void SendContentEvent(string eventName)
    {
        EventDispatcher.SendEvent(ContentEventType, new EventData(eventName));
    }
}
