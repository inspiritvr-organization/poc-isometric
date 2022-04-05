
using System.Collections.Generic;
public class ObjetTransform
{
    public ObjetTransform()
    {
        position = new List<float>();
        rotation = new List<float>();
        scale = new List<float>();
    }
    public List<float> position { get; set; }
    public List<float> rotation { get; set; }
    public List<float> scale { get; set; }
}

public class InteractionObject
{
    public InteractionObject()
    {
        objectTransform = new ObjetTransform();
    }
    public string objectID { get; set; }
    public string objectType { get; set; }
    public string objectLabel { get; set; }
    public ObjetTransform objectTransform { get; set; }
    public string objectThumbnailURL { get; set; }
}

public class InteractionPoints
{
    public List<InteractionObject> InteractionObjects { get; set; }
}
