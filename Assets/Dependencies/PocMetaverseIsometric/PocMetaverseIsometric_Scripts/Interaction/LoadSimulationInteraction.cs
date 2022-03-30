public class LoadSimulationInteraction : InteractionZone
{
    public string simulationLink;
    public string type;

    public override void Interact()
    {
        base.Interact();
        ReactHandler.CallReact(type,simulationLink);
    }

}
