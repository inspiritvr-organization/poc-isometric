using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed = 0.125f;

    [SerializeField] private Vector2 offset;
    private Vector2 limits;

    [SerializeField] private Transform floor;

    private Vector3 initialPosition;

    private void Awake()
    {
        initialPosition = transform.position;

        limits = floor.localScale / 4;
    }

    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + initialPosition;
        desiredPosition = new Vector3(
            Mathf.Clamp(desiredPosition.x, -limits.x - offset.x, limits.x + offset.x),
            desiredPosition.y,
            Mathf.Clamp(desiredPosition.z, -limits.y - offset.y, limits.y + offset.y)
        );

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
