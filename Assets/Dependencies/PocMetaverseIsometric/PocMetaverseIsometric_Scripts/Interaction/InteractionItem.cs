using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InteractionItem : MonoBehaviour
{
    [SerializeField] private Image thumbnail;
    [SerializeField] private TextMeshProUGUI labelText;

    public void UpdateLabelText(string labelString)
    {
        labelText.text = labelString;
    }


    public void UpdateThumbnail(Sprite thumbnailSprite)
    {
        thumbnail.sprite = thumbnailSprite;
    }
}
