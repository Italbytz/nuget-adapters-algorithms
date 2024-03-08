using System.Collections.Generic;

namespace Italbytz.Ports.Algorithms.AI.Learning;

public interface IDataSetSpecification
{
    public string TargetAttribute { get; }
    public bool IsValid(IEnumerable<string> uncheckedAttributes);

    public IEnumerable<string> GetAttributeNames();

    public IAttributeSpecification GetAttributeSpecFor(string name);
    IEnumerable<string> GetPossibleAttributeValues(string attributeName);
}