using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Page : MonoBehaviour
{
    public delegate void EventDelegate(Page page);
    public EventDelegate onClose;
    public EventDelegate onBack;

    public void Close()
    {
        onClose.Invoke(this);
    }

    public void Back()
    {
        onBack.Invoke(this);
    }
}
