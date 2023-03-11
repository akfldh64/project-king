using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventData
{
    public string name;
    public object value;

    public EventData(string name, object value)
    {
        this.name = name;
        this.value = value;
    }
}

public class EventDispatcher : Singleton<EventDispatcher>
{
    public delegate void EventDelegate(EventData eventData);

    private Dictionary<string, EventDelegate> delegates = new Dictionary<string, EventDelegate>();

    public static void SendEvent(string eventType, EventData eventData)
    {
        EventDelegate del;
        Instance.delegates.TryGetValue(eventType, out del);
        if (del != null)
            del.Invoke(eventData);
    }

    public static void Register(string eventType, EventDelegate del)
    {
        EventDelegate tmpDel;
        Instance.delegates.TryGetValue(eventType, out tmpDel);
        if (tmpDel != null)
            Instance.delegates[eventType] += del;
        else
            Instance.delegates[eventType] = del;
    }

    public static void UnRegister(string eventType, EventDelegate del)
    {
        EventDelegate tmpDel;
        Instance.delegates.TryGetValue(eventType, out tmpDel);
        if (tmpDel != null)
            Instance.delegates[eventType] -= del;
        else
            Instance.delegates.Remove(eventType);
    }
}
