// The original version of this file is part of <see href="https://github.com/aimacode/aima-java"/> which is released under
// MIT License
// Copyright (c) 2015 aima-java contributors

namespace Italbytz.Ports.Algorithms.AI.Learning;

public interface ILearner
{
    void Train(IDataSet ds);
    /// <summary>
    /// Returns the outcome predicted for the specified example
    /// </summary>
    /// <param name="e">an example</param>
    /// <returns>the outcome predicted for the specified example</returns>
    string Predict(IExample e);
    /// <summary>
    /// Returns the accuracy of the hypothesis on the specified set of examples
    /// </summary>
    /// <param name="ds">the test data set.</param>
    /// <returns>the accuracy of the hypothesis on the specified set of examples</returns>
    int[] Test(IDataSet ds);
}