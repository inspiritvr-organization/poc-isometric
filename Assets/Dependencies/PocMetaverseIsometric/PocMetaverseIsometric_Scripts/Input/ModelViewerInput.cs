using UnityEngine;
using UnityEngine.EventSystems;

public class ModelViewerInput : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    private Vector3 touchStart;
    private Vector2 mouseReference;
    [SerializeField] private float zoomOutMin = 1;
    [SerializeField] private float zoomOutMax = 8;
    [SerializeField] private float rotationSpeed = 0.5f;

    [SerializeField] private Transform modelBase;

    [SerializeField] Camera sceneCamera;

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
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            Zoom(difference * 0.01f);
        }

        Zoom(Input.GetAxis("Mouse ScrollWheel"));
    }

    private void Zoom(float increment)
    {
        sceneCamera.orthographicSize = Mathf.Clamp(sceneCamera.orthographicSize - increment, zoomOutMin, zoomOutMax);
    }

    private void Rotate(Vector2 deltaRotation)
    {
        modelBase.rotation = Quaternion.Euler(Mathf.Clamp(modelBase.rotation.y - deltaRotation.y, -90, 90), Mathf.Clamp(modelBase.rotation.x + deltaRotation.x, -180, 180), 0);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Rotate((mouseReference - eventData.position) * rotationSpeed);

        eventData.position = mouseReference;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        mouseReference = eventData.position;
    }
    public void BackToMain()
    {
        GameManager.Instance.LoadScene("IsometricRoom");
    }
}
