using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSimulationInteraction : InteractionObject
{
    public string simulationLink;
    public string type;

    public override void Interact()
    {
        base.Interact();
        ReactHandler.CallReact(type,simulationLink);
    }

}
