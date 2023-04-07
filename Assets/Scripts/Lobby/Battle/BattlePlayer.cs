using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattlePlayer : MonoBehaviour
{
    private long _totalArmy;
    public long totalArmy
    {
        get { return _totalArmy; }
        set
        {
            _totalArmy = value;
            UpdateUI();
        }
    }
    private long _currentArmy;
    public long currentArmy
    {
        get { return _currentArmy; }
        set
        {
            _currentArmy = value;
            UpdateUI();
        }
    }

    public Image hpGauge;
    public TextMeshProUGUI totalArmyText;
    public TextMeshProUGUI currentArmyText;

    public void UpdateUI()
    {
        totalArmyText.SetText($"Power: {_totalArmy.ToString()}");
        currentArmyText.SetText($"Army: {_currentArmy.ToString()}");

        if (_totalArmy > 0)
            hpGauge.fillAmount = ((float)_currentArmy/(float)_totalArmy);
        else
            hpGauge.fillAmount = 0f;
    }
}
