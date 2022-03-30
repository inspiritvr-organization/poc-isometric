using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField]private RectTransform enterRectTransform;

    public void SetStateEnterRectTransform(bool state)
    {
        enterRectTransform.gameObject.SetActive(state);
    }
}
