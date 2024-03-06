using System;
using System.Collections.Generic;
using Italbytz.Ports.Algorithms.AI.Learning;

namespace Italbytz.Adapters.Algorithms.Learning.Framework;

public class DataSetFactory
{
    public IDataSet FromFile(string filename, DataSetSpecification spec,
        string seperator)
    {
        throw new NotImplementedException();
    }

    public IDataSet FromString(string data, DataSetSpecification spec,
        string separator)
    {
        var dataSet = new DataSet(spec);
        var lines = data.Split('\n');
        foreach (var line in lines)
            dataSet.Examples.Add(ExampleFromString(line, spec, separator));

        return dataSet;
    }

    private static IExample ExampleFromString(string data,
        IDataSetSpecification dataSetSpec, string separator)
    {
        var attributes = new Dictionary<string, IAttribute>();
        var attributeValues = data.Split(separator);
        if (dataSetSpec.IsValid(attributeValues))
        {
        }

        throw new NotImplementedException();
    }
}