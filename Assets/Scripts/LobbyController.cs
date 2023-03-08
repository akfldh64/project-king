using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyController : MonoBehaviour
{
    public List<GameObject> pages;

    private int _pageIndex;
    public int pageIndex
    {
        get { return _pageIndex; }
        set
        {
            if (_pageIndex != value)
            {
                _pageIndex = value;
                LoadMenu(_pageIndex);
            }
        }
    }

    public void LoadMenu(int index)
    {
        for (int i = 0; i < pages.Count; ++i)
        {
            if (index == i)
                SetActive(pages[i], true);
            else
                SetActive(pages[i], false);
        }
    }

    private void SetActive(GameObject gameObject, bool isActive)
    {
        if (isActive != gameObject.activeSelf)
            gameObject.SetActive(isActive);
    }
}
