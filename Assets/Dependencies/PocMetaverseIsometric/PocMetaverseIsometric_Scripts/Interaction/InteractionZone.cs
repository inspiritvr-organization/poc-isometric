
using UnityEngine;

public class InteractionZone : MonoBehaviour
{

    private Outline outline;
    [SerializeField] private int reactIndex;
    private bool isWithinCharactersReach;

    private void Awake()
    {
        outline = GetComponent<Outline>();
    }

    public virtual void Interact()
    {
        ReactHandler.CallReact(reactIndex);
    }

    private void OnEnable()
    {
        IsometricSceneHandler.Instance.OnCharactersReach += isWithinReach;
        IsometricSceneHandler.Instance.inputManager.OnEnterPressed += OnInteraction;
    }
    private void OnDisable()
    {
        IsometricSceneHandler.Instance.OnCharactersReach -= isWithinReach;
        IsometricSceneHandler.Instance.inputManager.OnEnterPressed -= OnInteraction;
    }

    private void isWithinReach(GameObject gameObject)
    {
        if(gameObject== this.gameObject)
        {
            if (outline) outline.OutlineWidth = 3;
            this.isWithinCharactersReach = true;
        }
        else
        {
            if (outline) outline.OutlineWidth = 0;
            this.isWithinCharactersReach = false;
        }
        
    }

    private void OnInteraction()
    {
        if(this.isWithinCharactersReach)
        {
            Interact();
        }
    }
}
