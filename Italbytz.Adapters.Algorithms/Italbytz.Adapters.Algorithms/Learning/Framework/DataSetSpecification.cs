using System;
using System.Collections.Generic;
using System.Linq;
using Italbytz.Ports.Algorithms.AI.Learning;

namespace Italbytz.Adapters.Algorithms.Learning.Framework;

public class DataSetSpecification : IDataSetSpecification
{
    private readonly List<IAttributeSpecification> _attributeSpecifications;

    public DataSetSpecification()
    {
        _attributeSpecifications = new List<IAttributeSpecification>();
    }

    public string TargetAttribute { get; set; }

    public bool IsValid(IEnumerable<string> uncheckedAttributes)
    {
        var attributes = uncheckedAttributes.ToList();
        if (_attributeSpecifications.Count != attributes.Count)
            throw new SystemException(
                $"size mismatch specsize = {_attributeSpecifications.Count} attributes size = {attributes.Count}");
        throw new NotImplementedException();
    }

    public void DefineStringAttribute(string name, string[] attributeValues)
    {
        _attributeSpecifications.Add(new StringAttributeSpecification(name,
            attributeValues));
        TargetAttribute = name;
    }
}