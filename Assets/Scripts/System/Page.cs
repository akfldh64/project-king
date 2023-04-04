using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Page : MonoBehaviour
{
    public delegate void EventDelegate(GameObject go);
    public EventDelegate onClose;

    public void Close()
    {
        onClose.Invoke(gameObject);
        Destroy(gameObject);
    }
}
