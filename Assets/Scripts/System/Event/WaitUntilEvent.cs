using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitUntilLoginEvent : CustomYieldInstruction
{
    private string eventName;

    private bool _keepWaiting = true;
    public override bool keepWaiting { get { return _keepWaiting; } }

    public void Dispatch(EventData eventData)
    {
        if (eventData.name == eventName)
        {
            EventDispatcher.UnRegister("LOGIN", Dispatch);
            _keepWaiting = false;
        }
    }

    public WaitUntilLoginEvent(string eventName)
    {
        EventDispatcher.Register("LOGIN", Dispatch);
        this.eventName = eventName;
    }
}
