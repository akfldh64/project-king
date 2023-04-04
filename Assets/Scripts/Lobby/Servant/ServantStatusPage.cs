using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ServantStatusPage : Page
{
    public ServantInfo servantInfo;

    public TextMeshProUGUI level;
    public TextMeshProUGUI talent;
    public TextMeshProUGUI ability;

    public void Start()
    {
        UpdateInfo();
    }

    public void UpdateInfo()
    {
        level.SetText($"Level: {servantInfo.level}");
        talent.SetText($"Talent: {servantInfo.talent}");
        ability.SetText($"Ability: {servantInfo.ability}");
    }

    public void Upgrade()
    {
        if (servantInfo.level < 10)
        {
            servantInfo.AddExp(servantInfo.GetExpForLevelUp());
            UpdateInfo();
        }
    }
}
