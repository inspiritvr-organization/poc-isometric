using UnityEngine;

public class StudyGuideInteraction : InteractionZone
{
    [SerializeField]private string studyGuideLink;
    [SerializeField]private string type;

    public override void Interact()
    {
        base.Interact();
        ReactHandler.CallReact(type,studyGuideLink);
    }
}