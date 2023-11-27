using Italbytz.Adapters.Algorithms.Search.Agent;
using Italbytz.Adapters.Algorithms.Search.Framework.Problem;
using Italbytz.Adapters.Algorithms.Search.Local;
using Italbytz.Adapters.Algorithms.Tests.Environment.NQueens;
using Italbytz.Ports.Algorithms;

namespace Italbytz.Adapters.Algorithms.Tests;

public class NQueensHillClimbingTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var board = new NQueensBoard(8);
        var problem = new GeneralProblem<NQueensBoard, QueenAction>(board, NQueensFunctions.GetCSFActions, NQueensFunctions.GetResult, NQueensFunctions.GetTestGoal);
        var search = new HillClimbingSearch<NQueensBoard, QueenAction>(node => -NQueensFunctions.GetNumberOfAttackingPairs(node));
        var agent = new SearchAgent<IPercept, NQueensBoard, QueenAction>(problem, search);
        /*
         * 

        //Abstract Env

        public void step()
        {
            for (Agent <? super P, ? extends A > agent : agents) {
            if (agent.isAlive())
            {
                P percept = getPerceptSeenBy(agent);
                Optional <? extends A > anAction = agent.act(percept);
                if (anAction.isPresent())
                {
                    execute(agent, anAction.get());
                    notify(agent, percept, anAction.get());
                }
                else
                {
                    executeNoOp(agent);
                }
            }
        }
        createExogenousChange();
        */
    }
}
}
