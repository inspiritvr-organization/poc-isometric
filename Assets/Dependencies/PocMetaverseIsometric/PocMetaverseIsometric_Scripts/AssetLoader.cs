using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AssetLoader : MonoBehaviour
{
    [SerializeField]private List<ModelDownload> modelDownloads;

    public void DownloadAssets()
    {
        Debug.Log("Download has started");
        StartCoroutine(DownloadModels());
    }

    private IEnumerator DownloadModels()
    {
        if (modelDownloads.Count > 0)
        {
            foreach(ModelDownload modelDownload in modelDownloads)
            {
                yield return modelDownload.DownloadModel();
            }
        }
        yield return new WaitForEndOfFrame();
        ReactHandler.FinishModelLoading();
    }



    [ContextMenu("Download")]
    public void Download()
    {
        Debug.Log("Download has started");
        StartCoroutine(DownloadModels());
    }
}
