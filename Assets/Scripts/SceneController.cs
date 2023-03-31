using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public GameObject main;
    public List<GameObject> scenes;

    private int _sceneIndex;
    public int sceneIndex
    {
        get { return _sceneIndex; }
        set
        {
            if (_sceneIndex != value)
            {
                _sceneIndex = value;
                LoadScene(_sceneIndex);
            }
        }
    }

    private int lastIndex = 1;

    public void Awake()
    {
        scenes[0].GetComponent<Page>().onClose = (page) => {
            LoadMainScene();
        };
    }

    public void LoadMainScene()
    {
        LoadScene(lastIndex);
    }

    public void LoadScene(int index)
    {
        for (int i = 0; i < scenes.Count; ++i)
        {
            if (index == i)
            {
                SetActive(scenes[i], true);
                if (i == 1 || i == 2)
                    lastIndex = i;
            }
            else
                SetActive(scenes[i], false);
        }
    }

    private void SetActive(GameObject gameObject, bool isActive)
    {
        if (isActive != gameObject.activeSelf)
            gameObject.SetActive(isActive);
    }

    public void ShowLobby()
    {
        main.SetActive(true);
    }

    public void HideLobby()
    {
        main.SetActive(false);
    }
}
