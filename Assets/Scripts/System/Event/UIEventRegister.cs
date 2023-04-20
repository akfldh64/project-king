using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIEventRegister : MonoBehaviour
{
    [System.Serializable]
    public class UIDispatchEvent : UnityEvent<EventData>{}
    [System.Serializable]
    public class UIEventDelegate
    {
        public string eventName;
        public UIDispatchEvent delegator;
        public void Invoke(EventData eventData)
        {
            delegator.Invoke(eventData);
        }
    }

    public List<UIEventDelegate> eventDelegates = new List<UIEventDelegate>();
    private void Dispatch(EventData eventData)
    {
        foreach (var del in eventDelegates)
        {
            if (del.eventName == eventData.name)
                del.Invoke(eventData);
        }
    }

    const string eventType = "UI_EVENT";

    private void OnEnable()
    {
        EventDispatcher.Register(eventType, Dispatch);
    }
    private void OnDisable()
    {
        EventDispatcher.UnRegister(eventType, Dispatch);
    }
}
