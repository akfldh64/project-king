using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventListener : MonoBehaviour
{
    public string eventType;

    void SendMessage(EventData eventData)
    {
        gameObject.SendMessage(eventData.name, eventData.value, SendMessageOptions.DontRequireReceiver);
    }

    void OnEnable()
    {
        EventDispatcher.Register(eventType, SendMessage);
    }

    void OnDisable()
    {
        EventDispatcher.UnRegister(eventType, SendMessage);
        
    }
}
