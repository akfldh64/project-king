using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventListener : MonoBehaviour
{
    const string UI_EVENT_TYPE = "UI_EVENT";

    void SendMessage(EventData eventData)
    {
        gameObject.SendMessage(eventData.name, eventData.value, SendMessageOptions.DontRequireReceiver);
    }

    void OnEnable()
    {
        EventDispatcher.Register(UI_EVENT_TYPE, SendMessage);
    }

    void OnDisable()
    {
        EventDispatcher.UnRegister(UI_EVENT_TYPE, SendMessage);
        
    }
}
