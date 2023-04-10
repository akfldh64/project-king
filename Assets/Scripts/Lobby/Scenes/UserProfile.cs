using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserProfile : MonoBehaviour
{
    private UserInfo userInfo;

    public TextMeshProUGUI fundingText;
    public TextMeshProUGUI suppliesText;
    public TextMeshProUGUI armyText;

    void OnEnable()
    {
        userInfo = TempGlobalData.Instance.me;

        fundingText.SetText($"{userInfo.funding}");
        suppliesText.SetText($"{userInfo.supplies}");
        armyText.SetText($"{userInfo.army}");
    }
}
