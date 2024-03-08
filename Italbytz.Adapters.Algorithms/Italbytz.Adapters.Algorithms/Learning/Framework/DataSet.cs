using System;
using System.Collections;
using System.Collections.Generic;
using Italbytz.Ports.Algorithms.AI.Learning;

namespace Italbytz.Adapters.Algorithms.Learning.Framework;

public class DataSet : IDataSet
{
    public DataSet(IDataSetSpecification spec)
    {
        Examples = new List<IExample>();
        Specification = spec;
    }

    public IEnumerator<IExample> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public List<IExample> Examples { get; }
    public IDataSetSpecification Specification { get; }

    public IEnumerable<string> GetNonTargetAttributes()
    {
        return Util.Util.RemoveFrom(Specification.GetAttributeNames(),
            Specification.TargetAttribute);
    }

    public IEnumerable<string> GetPossibleAttributeValues(string attributeName)
    {
        return Specification.GetPossibleAttributeValues(attributeName);
    }
}