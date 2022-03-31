using UnityEngine;

public class ModelInteraction : InteractionZone
{
    [SerializeField] string url;
    //private ModelType thisModelType;
    public override void Interact()
    {
        base.Interact();
        AssetLoader.SetDownloadURL(url);
        GameManager.Instance.LoadScene("ModelViewerAssetBundle");
        //if(thisModelType==ModelType.trilib)
        //{
        //    GameManager.Instance.LoadScene("ModelViewerTrilib");
        //}
        //else
        //{
        //    GameManager.Instance.LoadScene("ModelViewerAssetBundle");
        //}
    }
}
