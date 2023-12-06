using Italbytz.Adapters.Algorithms.Agent;

namespace Italbytz.Adapters.Algorithms.Tests.Environment.Map;

public class MoveToAction : DynamicAction
{
    internal const string ATTRIBUTE_MOVE_TO_LOCATION = "location";

    public string ToLocation => (string)Attributes[ATTRIBUTE_MOVE_TO_LOCATION];

    public MoveToAction(string location) : base("moveTo")
    {
        Attributes[ATTRIBUTE_MOVE_TO_LOCATION] = location;
    }
}
