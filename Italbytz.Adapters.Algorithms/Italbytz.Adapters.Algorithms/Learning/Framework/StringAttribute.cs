using Italbytz.Ports.Algorithms.AI.Learning;

namespace Italbytz.Adapters.Algorithms.Learning.Framework;

public class StringAttribute : IAttribute
{
    private IAttributeSpecification _spec;
    private string _value;

    public StringAttribute(string value, StringAttributeSpecification spec)
    {
        _value = value;
        _spec = spec;
    }
}