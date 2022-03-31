
using System.Collections.Generic;
public class ObjetTransform
{
    public List<float> position { get; set; }
    public List<float> rotation { get; set; }
    public List<float> scale { get; set; }
}

public class InterationPoint
{
    public string id { get; set; }
    public string objectType { get; set; }
    public ObjetTransform Transform { get; set; }
    public string URL { get; set; }
}

public class PointsOfInteraction
{
    public List<InterationPoint> InterationPoints { get; set; }
}
