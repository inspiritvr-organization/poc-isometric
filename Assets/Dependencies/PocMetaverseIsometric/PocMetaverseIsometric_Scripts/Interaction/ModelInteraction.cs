using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ModelInteraction : InteractionObject
{
    //public string fileLocation;
    //public string assetName;
    //public string modelLink;
    //public string type;

    [SerializeField]private string modelURL;

    private GameObject modelObject;

    public override void Interact()
    {

        base.Interact();
        //ReactHandler.CallReact(type,modelLink);

    }

    public IEnumerator DownloadAndLoadModel()
    {
        UnityWebRequest uwr = UnityWebRequestAssetBundle.GetAssetBundle(modelURL);
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
            while (!abr.isDone)
            {
                yield return new WaitForEndOfFrame();
            }
            modelObject = Instantiate(abr.asset,this.transform) as GameObject;
        }


    }
}
