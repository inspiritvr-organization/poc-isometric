using System;
using UnityEngine;

public class IsometricSceneHandler : MonoBehaviour
{
    // Start is called before the first frame update

    public Action<GameObject> OnCharactersReach;
    public IsometricCharacterController character;
    public static IsometricSceneHandler Instance
    {
        get
        {
            return instance;
        }
        set
        {
            if (instance == null)
            {
                instance = value;
            }
        }
    }
    private static IsometricSceneHandler instance;

    [SerializeField] public InputManager inputManager;
    [SerializeField] private UIHandler uIHandler;
    [SerializeField] private GameObject interactableParent;

    private void OnEnable()
    {
        OnCharactersReach += WithinInteractionZone;
        inputManager.OnMoveUpdate += character.Move;
    }
    private void OnDisable()
    {
        OnCharactersReach -= WithinInteractionZone;
        inputManager.OnMoveUpdate -= character.Move;
    }
    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        interactableParent.SetActive(true);
    }

    private void WithinInteractionZone(GameObject intearctionObject)
    {
        if (intearctionObject == null)
        {
            uIHandler.SetStateEnterRectTransform(false);
        }
        else
        {
            uIHandler.SetStateEnterRectTransform(true);

        }
    }


    public void SetInputManagerState(bool state)
    {
        inputManager.enabled = state;
    }
}
