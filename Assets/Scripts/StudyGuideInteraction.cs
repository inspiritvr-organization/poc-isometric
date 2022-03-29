using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyGuideInteraction : InteractionObject
{
    [SerializeField]private string studyGuideLink;
    [SerializeField]private string type;

    public override void Interact()
    {
        base.Interact();
        ReactHandler.CallReact(type,studyGuideLink);
    }
}



/////CallStudyGuide
///studyGuideName