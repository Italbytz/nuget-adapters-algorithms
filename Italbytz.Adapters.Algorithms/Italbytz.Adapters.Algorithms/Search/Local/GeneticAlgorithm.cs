using System;
using System.Collections.Generic;

namespace Italbytz.Adapters.Algorithms.Search.Local
{
    public class GeneticAlgorithm<TAlphabet>
    {
        public GeneticAlgorithm(int individualLength,
            List<TAlphabet> finiteAlphabet, double mutationProbability) =>
            throw new NotImplementedException();

        public Individual<TAlphabet> ExecuteGeneticAlgorithm(
            List<Individual<TAlphabet>> initPopulation,
            Func<Individual<TAlphabet>, double> fitnessFn, int maxIterations) =>
            throw new NotImplementedException();
    }
}