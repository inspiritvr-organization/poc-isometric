using UnityEngine;
using System.Collections;
using System;

public class IsometricCharacterController : MonoBehaviour
{

    [Range(1.0f, 10.0f)]
    public float walkSpeed = 4f;

    [HideInInspector] public GameObject currentReachableObject;

    public Action<GameObject> NearbyObject;

    [SerializeField] private float speed = 5;
    [SerializeField] private float turnSpeed = 360;
    private Vector3 input;

    Rigidbody mRigidbody;

    private void Awake()
    {
        mRigidbody = GetComponent<Rigidbody>();
    }

    public void GetInput(float x, float y)
    {
        input = new Vector3(x, 0, y);
    }

    private void Update()
    {
        Look();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Look()
    {
        if (input == Vector3.zero) return;

        var rot = Quaternion.LookRotation(input.ToIso(), Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, turnSpeed * Time.deltaTime);
    }

    private void Move()
    {
        mRigidbody.MovePosition(transform.position + transform.forward * input.normalized.magnitude * speed * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.GetComponent<InteractionFocus>()) return;

        other.gameObject.GetComponent<InteractionFocus>().ShowItem(true);

        currentReachableObject = other.gameObject;
        IsometricSceneHandler.Instance.OnCharactersReach?.Invoke(currentReachableObject);
    }
    public void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.GetComponent<InteractionFocus>()) return;

        other.gameObject.GetComponent<InteractionFocus>().ShowItem(false);

        currentReachableObject = null;
        IsometricSceneHandler.Instance.OnCharactersReach?.Invoke(currentReachableObject);
    }
}

public static class Helpers
{
    private static Matrix4x4 _isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
    public static Vector3 ToIso(this Vector3 input) => _isoMatrix.MultiplyPoint3x4(input);
}

