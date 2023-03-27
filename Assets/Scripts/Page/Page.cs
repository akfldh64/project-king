using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Page : MonoBehaviour
{
    public GameObject caller;

    public void Close()
    {
        OnClose(); 
    }

    protected virtual void OnClose() {}
}
