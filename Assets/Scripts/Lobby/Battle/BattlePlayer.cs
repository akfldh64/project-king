using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattlePlayer : MonoBehaviour
{
    private long _totalArmy;
    public long totalArmy
    {
        get { return _totalArmy; }
        set
        {
            armyText.SetText($"Power: {value.ToString()}");
            _totalArmy = value;
        }
    }
    private long _currentArmy;
    public long currentArmy
    {
        get { return _currentArmy; }
        set
        {
            currentText.SetText($"Army: {value.ToString()}");
            _currentArmy = value;
        }
    }

    public TextMeshProUGUI armyText;
    public TextMeshProUGUI currentText;
}
