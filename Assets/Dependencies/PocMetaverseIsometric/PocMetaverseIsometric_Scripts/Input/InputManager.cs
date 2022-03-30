using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Action<float, float> OnMoveUpdate;
    public Action OnEnterPressed;


    private void OnEnable()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        WebGLInput.captureAllKeyboardInput = true;
#endif
    }
    private void OnDisable()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        WebGLInput.captureAllKeyboardInput = false;
#endif
    }
    public void FixedUpdate()
    {
        if (Input.anyKey)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                OnEnterPressed?.Invoke();
            }
            else
            {
                OnMoveUpdate?.Invoke(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            }
        }

    }
}
