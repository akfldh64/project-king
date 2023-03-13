using UnityEngine;

public class MonoWeakSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                var founds = FindObjectsOfType(typeof(T));
                if (founds.Length > 1)
                {
                    Debug.LogError("[Weak Singleton] Singlton '" + typeof(T) + "' should never be more than 1!");
                }
                else if (founds.Length == 0)
                {
                    Debug.LogError("[Weak Singleton] Singleton '" + typeof(T) + "' is not exist in this scene!");
                }
                else
                {
                    _instance = (T)founds[0];
                }
            }
            return _instance;
        }
    }

    protected virtual void OnDestroy()
    {
        _instance = null;
    }
}
