using System.Collections.Generic;

namespace Italbytz.Ports.Algorithms.AI.Learning;

public interface IDataSet : IEnumerable<IExample>
{
    public List<IExample> Examples { get; }
    public IDataSetSpecification Specification { get; set; }
    IEnumerable<string> GetNonTargetAttributes();
    IEnumerable<string> GetPossibleAttributeValues(string attributeName);
    IDataSet EmptyDataSet();
    double CalculateGainFor(string parameterName);
    IDataSet MatchingDataSet(string attributeName, string attributeValue);

    public double GetInformationFor();
}