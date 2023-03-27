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

    public void Awake()
    {
        for (int i = 0; i < scenes.Count; ++i)
            scenes[i].GetComponent<Page>().caller = this.gameObject;
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

    public void ShowUI()
    {
        main.SetActive(true);
    }

    public void HideUI()
    {
        main.SetActive(false);
    }

    private Page page;

    public void LoadPage(string assetName)
    {
        var page = Instantiate(AssetManager.Instance.LoadAsset<GameObject>("lobby", assetName));
        page.transform.SetParent(gameObject.transform, false);
        page.gameObject.name = assetName;
        page.GetComponent<Page>().caller = this.gameObject;
    }

    public void Closed(GameObject callee)
    {
        Destroy(callee);
        ShowUI();
    }
}
