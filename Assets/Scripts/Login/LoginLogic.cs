using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaitUntilEvent : CustomYieldInstruction
{
    private bool isWaiting = true;
    private string eventName;

    public override bool keepWaiting { get { return isWaiting; } }

    public void OnEvent(EventData eventData)
    {
        if (eventData.name == eventName)
            isWaiting = false;
    }

    public WaitUntilEvent(string eventName)
    {
        this.eventName = eventName;
        EventDispatcher.Register("UI_EVENT", OnEvent);
    }
}

public class LoginLogic : MonoBehaviour
{
    private const int LOBBY_SCENE_ID = 1;

    public void Start()
    {
        StartCoroutine(Logic());
    }

    public IEnumerator Logic()
    {
        yield return new WaitUntilEvent("Start");

        var operation = AssetManager.Instance.LoadAssetBundle("lobby");

        yield return new WaitUntil(() => operation.IsDone());

        SceneManager.LoadScene(LOBBY_SCENE_ID, LoadSceneMode.Single);
    }
}
