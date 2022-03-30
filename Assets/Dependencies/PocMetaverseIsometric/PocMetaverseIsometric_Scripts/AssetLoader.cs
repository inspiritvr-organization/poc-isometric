using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class AssetLoader : MonoBehaviour
{
    public List<ModelInteraction> modelInteractions;

    [ContextMenu ("Download Models")]
    public void DownloadAssets()
    {
        StartCoroutine(DownloadModels());
    }

    public IEnumerator DownloadModels()
    {
        if (modelInteractions.Count > 0)
        {
            foreach(ModelInteraction modelInteraction in modelInteractions)
            {
                yield return modelInteraction.DownloadAndLoadModel();
            }
        }
        yield return new WaitForEndOfFrame();
    }
}
