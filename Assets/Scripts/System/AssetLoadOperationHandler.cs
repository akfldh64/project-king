using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetLoadOperationHandler : MonoBehaviour
{
    private Queue<AssetBundleLoadOperation> operationQueue = new Queue<AssetBundleLoadOperation>();

    public void Enqueue(AssetBundleLoadOperation operation)
    {
        operationQueue.Enqueue(operation);
    }

    private void Update()
    {
        if (operationQueue.Count > 0)
            StartCoroutine(operationQueue.Dequeue().Load());
    }
}
