using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
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

    public void LoadScene(int index)
    {
        for (int i = 0; i < scenes.Count; ++i)
        {
            if (index == i)
                SetActive(scenes[i], true);
            else
                SetActive(scenes[i], false);
        }
    }

    private void SetActive(GameObject gameObject, bool isActive)
    {
        if (isActive != gameObject.activeSelf)
            gameObject.SetActive(isActive);
    }
}
