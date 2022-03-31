using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AssetLoader : MonoBehaviour
{
    [SerializeField]private AssetBundleModelDownload modelDownload;

    private static string urlToDownload;
    private static string versionString;
    public static void SetDownloadURL(string URL,string version="")
    {
        urlToDownload = URL;
        versionString = version;
    }

    public void Start()
    {
        StartCoroutine(DownloadModels(urlToDownload));
    }

    private IEnumerator DownloadModels(string url,string version="")
    {

        yield return modelDownload.DownloadModel(url, version);
        yield return new WaitForEndOfFrame();
    }
}
