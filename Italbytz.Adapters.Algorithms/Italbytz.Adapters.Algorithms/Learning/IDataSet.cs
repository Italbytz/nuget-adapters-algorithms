using System.Collections.Generic;

namespace Italbytz.Ports.Algorithms.AI.Learning;

public interface IDataSet : IEnumerable<IExample>
{
    public List<IExample> Examples { get; }
    public IDataSetSpecification Specification { get; }
}