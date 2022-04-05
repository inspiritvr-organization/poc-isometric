using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField]private RectTransform enterRectTransform;
    [SerializeField] private Button enterButton;

    public void SetStateEnterRectTransform(bool state)
    {
        enterRectTransform.gameObject.SetActive(state);
    }

    private void Start()
    {
        enterButton.onClick.AddListener(() => { IsometricSceneHandler.Instance.inputManager.OnEnterPressed?.Invoke(); });
    }
}
