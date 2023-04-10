using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WivesPage : Page
{
    public Button closeBtn;

    public void OnEnable()
    {
        closeBtn.onClick.AddListener(Close);
    }

    public void OnDisable()
    {
        closeBtn.onClick.RemoveListener(Close);
    }
}
