using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginLogic : MonoBehaviour
{
    private const int LOBBY_SCENE_ID = 1;

    public Button loginBtn;

    private void OnEnable()
    {
        loginBtn.onClick.AddListener(() => EventDispatcher.SendEvent("LOGIN", new EventData("Start")));

        StartCoroutine(Logic());
    }

    private void OnDisable()
    {
        loginBtn.onClick.RemoveListener(() => EventDispatcher.SendEvent("LOGIN", new EventData("Start")));
    }

    private IEnumerator Logic()
    {
        yield return new WaitUntilLoginEvent("Start");

        var operation = AssetManager.Instance.LoadAssetBundle("lobby");

        yield return new WaitUntil(() => operation.IsDone());

        SceneManager.LoadScene(LOBBY_SCENE_ID, LoadSceneMode.Single);
    }
}
