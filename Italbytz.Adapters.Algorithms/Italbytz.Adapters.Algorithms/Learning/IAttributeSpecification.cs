namespace Italbytz.Ports.Algorithms.AI.Learning;

public interface IAttributeSpecification
{
    IAttribute CreateAttribute(string rawValue);

    bool IsValid(string value);
}