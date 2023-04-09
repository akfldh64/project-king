using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoWeakSingleton<PopupManager>
{
    public GameObject background;
    public Transform anchor;

    private Popup popup;

    public T Open<T>(string bundleName, string assetName, Popup<T>.EventDelegate onOpen) where T : Popup<T>
    {
        var obj = Instantiate(AssetManager.Instance.LoadAsset<GameObject>(bundleName, assetName));

        T popup = obj.GetComponent<T>();
        if (popup == null)
            return null;
            
        obj.gameObject.name = assetName;
        obj.transform.SetParent(anchor, false);
        popup.onOpen += onOpen;
        popup.onClose += (popup) => Close();

        background.SetActive(true);
        this.popup = popup;

        return popup;
    }

    public void Close()
    {
        if (popup == null)
            return;

        Destroy(popup.gameObject);
        popup = null;

        background.SetActive(false);
    }
}
