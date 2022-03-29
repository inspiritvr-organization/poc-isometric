using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public Action<InteractionObject> OnTriggerActor;
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
        inputManager.OnMoveUpdate += MoveCharacter;
    }
    private void OnDisable()
    {
        OnTriggerActor -= WithinInteractionZone;
        inputManager.OnMoveUpdate -= MoveCharacter;
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

    private void MoveCharacter(float x, float y)
    {
        character.Move(x, y);
    }

    private void WithinInteractionZone(InteractionObject interactionObject)
    {
        character.currentInteractingObject = interactionObject;
        if (interactionObject == null)
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

    private void LoadObjectBasedOnType()
    {
        if (character.currentInteractingObject != null)
        {
            character.currentInteractingObject.Interact();
        }
    }
}
