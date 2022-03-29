
using UnityEngine;

public class InteractionObject : MonoBehaviour
{

    public virtual void Interact()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("GameController"))
        {
            GameManager.Instance.OnTriggerActor?.Invoke(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("GameController"))
        {
            GameManager.Instance.OnTriggerActor?.Invoke(null);
        }
    }
}
