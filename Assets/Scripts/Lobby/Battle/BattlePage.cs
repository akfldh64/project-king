using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage
{
    public int level;
    public int currentLevel;
    public List<long> enemyArmyList;
}

public class BattlePage : Page
{
    public BattleLogic logic;

    public Button playBtn;
    public Button closeBtn;

    public Stage stage = new Stage();
    public List<GameObject> levelCounters;

    public void OnEnable()
    {
        stage.level = 6;
        stage.currentLevel = 0;
        stage.enemyArmyList = new List<long>{ 10, 30, 50, 100, 150, 200, 250 };

        playBtn.onClick.AddListener(Play);
        closeBtn.onClick.AddListener(Close);

        logic.Initialize();
    }

    public void SetLevel(int level)
    {
        for (int i = 0; i < stage.level; i++)
        {
            if (i < stage.currentLevel)
                levelCounters[i].SetActive(true);
            else
                levelCounters[i].SetActive(false);
        }
    }

    public void Play()
    {
        logic.Play();
    }

    public override void Close()
    {
        logic.StopAllCoroutines();
        base.Close();
    }
}
