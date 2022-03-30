using UnityEngine;
using System.Collections;

public class IsometricCharacterController : MonoBehaviour
{

    [Range(1.0f, 10.0f)]
    public float walkSpeed = 4f;

    [HideInInspector]public InteractionObject currentInteractingObject;
    Vector3 forward, right;
    [SerializeField]BoxCollider collider;
    RaycastHit hit;
    [Range(0,2.0f)]float slopeHeight=0.5f;

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

}
