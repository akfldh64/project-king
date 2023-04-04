using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Page : MonoBehaviour
{
    public delegate void EventDelegate(GameObject go);
    public EventDelegate onClose;

    public virtual void Close()
    {
        onClose.Invoke(gameObject);
        Destroy(gameObject);
    }
}

public abstract class StaticPage : Page
{
    public override void Close()
    {
        onClose.Invoke(gameObject);
    }
}
