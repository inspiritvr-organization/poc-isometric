using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformInteraction : MonoBehaviour
{
    public void OnMouseDrag()
    {
        float XaxisRotation = Input.GetAxis("Mouse X") * 0.2f;
        float YaxisRotation = Input.GetAxis("Mouse Y") * 0.2f;
        this.transform.Rotate(Vector3.down, XaxisRotation);
        this.transform.Rotate(Vector3.right, YaxisRotation);
    }
}
