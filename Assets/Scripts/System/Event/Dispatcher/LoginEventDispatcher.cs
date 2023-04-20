using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LoginEventDispatcher : MonoBehaviour
{
    private Dictionary<string, EventDispatcher.EventDelegate> delegates = new Dictionary<string, EventDispatcher.EventDelegate>();
    private void Dispatch(EventData eventData)
    {
        EventDispatcher.EventDelegate del;
        if (delegates.TryGetValue(eventData.name, out del))
            del.Invoke(eventData);
    }

    protected void RegisterEvent(string eventName, EventDispatcher.EventDelegate eventDelegate)
    {
        delegates.Add(eventName, eventDelegate);
    }

    protected void UnRegisterEvent(string eventName)
    {
        delegates.Remove(eventName);
    }

    protected virtual void OnEnable()
    {
        EventDispatcher.Register("LOGIN", Dispatch);
    }

    protected virtual void OnDisable()
    {
        EventDispatcher.UnRegister("LOGIN", Dispatch);
    }
}