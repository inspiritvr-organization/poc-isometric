using UnityEngine;
using System.Collections;
using System;

public class IsometricCharacterController : MonoBehaviour
{

    [Range(1.0f, 10.0f)]
    public float walkSpeed = 4f;

    [HideInInspector] public GameObject currentReachableObject;
    Vector3 forward, right;
    public Action<GameObject> NearbyObject;


    private void Start()
    {

        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }

    public void Move(float x, float y)
    {
        Vector3 rightMovement = right * walkSpeed * x;
        Vector3 upMovement = forward * walkSpeed * y;
        Vector3 forwardDirection = Vector3.Normalize(rightMovement + upMovement);

        Vector3 newPosition = transform.position;
        newPosition += rightMovement;
        newPosition += upMovement;

        if (x != 0 || y != 0)
        {
            transform.forward = forwardDirection;
        }
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime);


    }

    public void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<InteractionItem>()?.ShowItem(true);

        currentReachableObject = other.gameObject;
        IsometricSceneHandler.Instance.OnCharactersReach?.Invoke(currentReachableObject);
    }
    public void OnTriggerExit(Collider other)
    {
        other.gameObject.GetComponent<InteractionItem>()?.ShowItem(false);

        currentReachableObject = null;
        IsometricSceneHandler.Instance.OnCharactersReach?.Invoke(currentReachableObject);
    }

}
