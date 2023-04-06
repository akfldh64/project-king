using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BattleLogic : MonoBehaviour
{
    public BattlePage page;

    public BattlePlayer enemy;
    public BattlePlayer player;

    public UserInfo userInfo;

    public void Initialize()
    {
        userInfo = TempGlobalData.Instance.me;
        player.totalArmy = player.currentArmy = userInfo.army;

        EnterStage();
    }

    public void EnterStage()
    {
        if (page.stage.currentLevel < page.stage.level)
        {
            page.stage.currentLevel++;
            page.SetLevel(page.stage.currentLevel);
            enemy.totalArmy = enemy.currentArmy = page.stage.enemyArmyList[page.stage.currentLevel];
        }
    }

    public void Play()
    {
        StartCoroutine(PlayCoroutine());
    }

    public IEnumerator PlayCoroutine()
    {
        page.playBtn.gameObject.SetActive(false);

        if (Battle())
        {
            EnterStage();
        }
        yield return new WaitForSeconds(0.5f);

        page.playBtn.gameObject.SetActive(true);
    }

    public bool Battle()
    {
        bool isWin = false;

        player.currentArmy = Convert.ToInt64(Mathf.Max(0f, player.currentArmy - enemy.currentArmy));
        enemy.currentArmy = Convert.ToInt64(Mathf.Max(0f, enemy.currentArmy - player.currentArmy));

        if (enemy.currentArmy == 0)
        {
            isWin = true;
        }
        else
        {
            isWin = false;
        }
        return isWin;
    }
}
