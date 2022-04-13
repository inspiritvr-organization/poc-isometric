using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerControlSwitcher : MonoBehaviour
{
    [SerializeField] private Toggle switcherToggle;
    private IsometricCharacterController keyboardController;
    private PlayerClickToMove clickToMoveController;
    private NavMeshAgent agent;

    private Rigidbody mRigidbody;

    private Collider mCollider;

    [DllImport("__Internal")]
    private static extern bool IsMobile();

    private void Awake()
    {
        keyboardController = GetComponent<IsometricCharacterController>();
        clickToMoveController = GetComponent<PlayerClickToMove>();
        mRigidbody = GetComponent<Rigidbody>();
        mCollider = GetComponent<Collider>();
        agent = GetComponent<NavMeshAgent>();

        clickToMoveController.OnClickMovementStarted += DisableKeyboard;
        clickToMoveController.OnClickMovementFinished += EnableKeyboard;

        // if (!DeviceIsMobile())
        // {
        //     switcherToggle.gameObject.SetActive(true);
        //     switcherToggle.isOn = true;
        // }
    }

    public void EnableKeyboard()
    {
        SetKeyboard(true);
    }

    public void DisableKeyboard()
    {
        SetKeyboard(false);
    }

    public void SetKeyboard(bool isActive)
    {
        if (isActive)
        {
            mCollider.isTrigger = false;
            mRigidbody.useGravity = true;
            keyboardController.enabled = true;
            // agent.enabled = false;
            // clickToMoveController.enabled = false;
        }
        else
        {
            keyboardController.enabled = false;
            mRigidbody.useGravity = false;
            mCollider.isTrigger = true;
            // agent.enabled = true;
            // clickToMoveController.enabled = true;
        }
    }

    public bool DeviceIsMobile()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
        return IsMobile();
#endif
        return false;
    }

    private void OnDestroy()
    {
        clickToMoveController.OnClickMovementStarted -= EnableKeyboard;
        clickToMoveController.OnClickMovementFinished -= DisableKeyboard;
    }
}
