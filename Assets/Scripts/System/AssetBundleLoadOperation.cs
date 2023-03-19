using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AssetBundleLoadStatus
{
    None      = 0,
    Succeeded = 1,
    Failed    = 2
}

public abstract class AssetBundleLoadOperation
{
    protected UnityEngine.Object asset;
    protected AssetBundleLoadStatus loadStatus = AssetBundleLoadStatus.None;

    public UnityEngine.Object GetAsset() => asset;
    public virtual bool IsDone() { return loadStatus == AssetBundleLoadStatus.Succeeded; }
    public virtual IEnumerator Load() { yield return null; }
}

public class AssetBundleLoadSimulation : AssetBundleLoadOperation
{
    public AssetBundleLoadSimulation()
    {
        loadStatus = AssetBundleLoadStatus.Succeeded;
    }
}
