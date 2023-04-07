using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleResultPopup : Popup<BattleResultPopup>
{
    public GameObject winObj;
    public GameObject loseObj;

    public Button closeBtn;

    public bool isWin;

    public void OnEnable()
    {
        closeBtn.onClick.AddListener(Close);

        if (isWin)
        {
            winObj.SetActive(true);
            loseObj.SetActive(false);
        }
        else
        {
            winObj.SetActive(false);
            loseObj.SetActive(true);
        }
    }
}
