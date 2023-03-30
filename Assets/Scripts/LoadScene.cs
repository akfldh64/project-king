using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadScene : MonoBehaviour
{
    const int LOBBY_SCENE_ID = 1;

    public void Load()
    {
        StartCoroutine(LoadBundle("lobby"));
    }

    public IEnumerator LoadBundle(string bundleName)
    {
        var operation = AssetManager.Instance.LoadAssetBundle(bundleName);

        yield return new WaitUntil(() => operation.IsDone());

        SceneManager.LoadScene(LOBBY_SCENE_ID, LoadSceneMode.Single);
    }
}