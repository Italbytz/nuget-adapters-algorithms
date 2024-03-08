using System.Collections.Generic;

namespace Italbytz.Ports.Algorithms.AI.Learning;

public interface IExample
{
    Dictionary<string, IAttribute> Attributes { get; }

    public string TargetValue();

    public string GetAttributeValueAsString(string attributeName);
}