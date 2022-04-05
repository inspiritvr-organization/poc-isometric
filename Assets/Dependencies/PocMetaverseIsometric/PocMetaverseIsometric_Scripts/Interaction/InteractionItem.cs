using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Networking;

public class InteractionItem : MonoBehaviour
{
    [SerializeField] private Image thumbnail;
    [SerializeField] private TextMeshProUGUI labelText;

    public void UpdateLabelText(string labelString)
    {
        labelText.text = labelString;
    }


    public void UpdateThumbnail(string thumbnailString)
    {
        if(string.IsNullOrEmpty(thumbnailString))
        {
            DownloadThumbnail downloadThumbnail = new DownloadThumbnail(ref thumbnail, thumbnailString);
            StartCoroutine(downloadThumbnail.Download());
        }
    }

    
}
