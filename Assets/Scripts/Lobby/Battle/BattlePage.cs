using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattlePage : Page
{
    public Button closeBtn;

    public void OnEnable()
    {
        closeBtn.onClick.AddListener(Close);
    }
}
