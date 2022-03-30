using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Action<InteractionZone> OnTriggerActor;
    public IsometricCharacterController character;

   [SerializeField] private InputManager inputManager;
   [SerializeField] private UIHandler uIHandler;
   
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
        set
        {
            if(instance==null)
            {
                instance = value;
            }
        }
    }
    private static GameManager instance;

    private void OnEnable()
    {
        OnTriggerActor += WithinInteractionZone;
        inputManager.OnMoveUpdate += character.Move;
    }
    private void OnDisable()
    {
        OnTriggerActor -= WithinInteractionZone;
        inputManager.OnMoveUpdate -= character.Move;
    }

    private void Awake()
    {
        if(Instance==null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void WithinInteractionZone(InteractionZone interactionZone)
    {
        character.currentIInteractionZone = interactionZone;
        if (interactionZone == null)
        {
            uIHandler.SetStateEnterRectTransform(false);
            inputManager.OnEnterPressed -= LoadObjectBasedOnType;
        }
        else
        {
            uIHandler.SetStateEnterRectTransform(true);
            inputManager.OnEnterPressed += LoadObjectBasedOnType;

        }
    }


    public void SetInputManagerState(bool state)
    {
        inputManager.enabled = state;
    }


    private void LoadObjectBasedOnType()
    {
        if (character.currentIInteractionZone != null)
        {
            character.currentIInteractionZone.Interact();
        }
    }
}
