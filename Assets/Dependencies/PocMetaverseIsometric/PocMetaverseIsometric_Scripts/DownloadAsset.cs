using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class DownloadAsset
{
    string assetURL;
    public DownloadAsset(string url)
    {
        assetURL = url;
    }
    public IEnumerator DownloadAssetBundle(Action<UnityEngine.Object> OnAssetLoaded)
    {
        UnityWebRequest uwr = UnityWebRequestAssetBundle.GetAssetBundle(assetURL);
        yield return uwr.SendWebRequest();
        while (!uwr.isDone)
        {
            yield return new WaitForEndOfFrame();
        }
        if (uwr.result != UnityWebRequest.Result.Success && uwr.isDone)
        {
            Debug.Log("DownloadFailed");
        }
        else
        {
            AssetBundle assetBundle = DownloadHandlerAssetBundle.GetContent(uwr);
            AssetBundleRequest abr = assetBundle.LoadAllAssetsAsync();
            yield return abr.isDone;
            OnAssetLoaded?.Invoke(abr.asset);

            assetBundle.Unload(false);
            abr = null;
            uwr.Dispose();
        }


    }
}
