
using UnityEngine;

public class InteractionObject : MonoBehaviour
{

    private Outline outline;

    private void Awake()
    {
        outline = GetComponent<Outline>();
    }

    public virtual void Interact()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GameController"))
        {
            if (outline) outline.OutlineWidth = 3;
            GameManager.Instance.OnTriggerActor?.Invoke(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("GameController"))
        {
            if (outline) outline.OutlineWidth = 0;
            GameManager.Instance.OnTriggerActor?.Invoke(null);
        }
    }
}
