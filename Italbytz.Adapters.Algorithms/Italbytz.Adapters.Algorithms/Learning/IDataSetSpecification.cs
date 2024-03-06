using System.Collections.Generic;

namespace Italbytz.Ports.Algorithms.AI.Learning;

public interface IDataSetSpecification
{
    bool IsValid(IEnumerable<string> uncheckedAttributes);
}