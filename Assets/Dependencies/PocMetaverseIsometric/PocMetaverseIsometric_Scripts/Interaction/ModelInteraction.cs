using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelInteraction : InteractionObject
{
    //public string fileLocation;
    //public string assetName;
    public string modelLink;
    public string type;


    public override void Interact()
    {

        base.Interact();
        ReactHandler.CallReact(type,modelLink);


        //StartCoroutine(LoadModel(fileLocation, assetName));
    }

    private IEnumerator LoadModel(string fileLocation, string assetName)
    {
#if UNITY_EDITOR 
        AssetBundleCreateRequest abcr = AssetBundle.LoadFromFileAsync(Application.dataPath + "/" + fileLocation);
        yield return abcr.isDone;
        GameObject g1 = abcr.assetBundle.LoadAsset<GameObject>(assetName);
#else
        AssetBundleCreateRequest abcr = AssetBundle.LoadFromFileAsync(fileLocation);
        yield return abcr.isDone;
        GameObject g1 = abcr.assetBundle.LoadAsset<GameObject>(assetName);

#endif
    }
}
