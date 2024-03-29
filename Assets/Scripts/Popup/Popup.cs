using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Popup : MonoBehaviour {}

public abstract class Popup<T> : Popup where T : MonoBehaviour
{
    public delegate void EventDelegate(T popup);

    public EventDelegate onClose;
    public virtual void Close()
    {
        onClose.Invoke(this as T);
    }

    public EventDelegate onOpen;
    public virtual void Open()
    {
        onOpen.Invoke(this as T);
        Initialize();
    }
    public abstract void Initialize();
}
