using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class DownloadThumbnail
{
    private string downloadURL;
    private Image image;
    public DownloadThumbnail(ref Image imageComponent, string url)
    {
        image = imageComponent;
        downloadURL = url;
    }
    public IEnumerator Download()
    {
        UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(downloadURL);
        yield return uwr.SendWebRequest();
        if (uwr.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("Connection Error");
        }
        Texture2D texture = new Texture2D(0, 0);
        texture.LoadImage(uwr.downloadHandler.data);
        image.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one / 2);
        image.preserveAspect = true;

    }
}
