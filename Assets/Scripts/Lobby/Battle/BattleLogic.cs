using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BattleLogic : MonoBehaviour
{
    public BattlePage page;
    public BattlePlayer enemy;
    public BattlePlayer player;

    private UserInfo userInfo;

    public void Initialize()
    {
        userInfo = TempGlobalData.Instance.me;
        player.totalArmy = player.currentArmy = userInfo.army;
        NextLevel();
    }

    public void Play()
    {
        StartCoroutine(PlayCoroutine());
    }

    public IEnumerator PlayCoroutine()
    {
        page.playBtn.gameObject.SetActive(false);

        yield return StartCoroutine(Battle());

        if (ClearLevel())
        {
            if (NextLevel())
                OpenResultPopup(true);
            else
                page.Close();
        }
        else
        {
            OpenResultPopup(false);
        }
    }

    public void OpenResultPopup(bool isWin)
    {
        var popup = PopupManager.Instance.Open<BattleResultPopup>("lobby", "Battle Result Popup", (BattleResultPopup popup) => {
            popup.isWin = isWin;
            popup.onClose += (popup) => {
                if (popup.isWin)
                {
                    popup.gameObject.SetActive(false);
                    page.playBtn.gameObject.SetActive(true);
                }
                else
                {
                    page.Close();
                }
            };
        });
        popup.Open();
    }

    public bool ClearLevel()
    {
        return enemy.currentArmy == 0;
    }

    public bool NextLevel()
    {
        if (page.stage.currentLevel == page.stage.level)
            return false;

        page.stage.currentLevel++;
        page.SetLevel(page.stage.currentLevel);
        enemy.totalArmy = enemy.currentArmy = page.stage.enemyArmyList[page.stage.currentLevel];

        return true;
    }

    public IEnumerator Battle()
    {
        yield return new WaitForSeconds(0.5f);

        long playerHp = Convert.ToInt64(Mathf.Max(0f, player.currentArmy - enemy.currentArmy));
        long enemyHp = Convert.ToInt64(Mathf.Max(0f, enemy.currentArmy - player.currentArmy));
        player.currentArmy = playerHp;
        enemy.currentArmy = enemyHp;
    }
}
