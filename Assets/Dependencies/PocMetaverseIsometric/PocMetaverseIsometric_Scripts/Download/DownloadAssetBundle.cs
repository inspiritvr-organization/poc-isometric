using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DownloadAssetBundle
{

    Hash128 versionHash;
    List<Hash128> previousVersions;
    bool bundleCachable;
    public DownloadAssetBundle()
    {
        versionHash = new Hash128();
        bundleCachable = false;
    }

    public IEnumerator Download(string url, Action<UnityEngine.Object> OnAssetLoaded = null, string version = "")
    {
        UnityWebRequest uwr;
        if (String.IsNullOrEmpty(version))
        {
            uwr = UnityWebRequestAssetBundle.GetAssetBundle(uri: url);
            bundleCachable = false;
        }
        else
        {
            bundleCachable = true;
            versionHash.Append(version);
            uwr = UnityWebRequestAssetBundle.GetAssetBundle(uri: url, hash: versionHash);

        }
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
            if (bundleCachable)
            {
                Caching.GetCachedVersions(assetBundle.name, previousVersions);
                Caching.ClearOtherCachedVersions(assetBundle.name, versionHash);
                previousVersions.Clear();
            }
            AssetBundleRequest abr = assetBundle.LoadAllAssetsAsync();
            yield return abr.isDone;
            OnAssetLoaded?.Invoke(abr.asset);
            assetBundle.Unload(false);
            abr = null;
            uwr.Dispose();
        }


    }
}


