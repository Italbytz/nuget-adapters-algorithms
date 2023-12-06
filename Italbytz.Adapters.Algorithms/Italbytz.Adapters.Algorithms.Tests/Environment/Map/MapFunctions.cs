using Italbytz.Adapters.Algorithms.Util;
using Italbytz.Ports.Algorithms.AI.Search;

namespace Italbytz.Adapters.Algorithms.Tests.Environment.Map;

public class MapFunctions
{
    public static Func<string, List<MoveToAction>> CreateActionsFunction(Map map)
    {
        return state => map.GetPossibleNextLocations(state)
            .Select(loc => new MoveToAction(loc)).ToList();
    }
    
    public static bool TestGoal(string arg) => arg.Equals(SimplifiedRoadMapOfPartOfRomania.BUCHAREST);

    public static Func<string,MoveToAction,string,double> CreateDistanceStepCostFunction(Map map)
    {
        return (state, action, statePrimed) => {
            double distance = map.GetDistance(state, statePrimed);
            // Used by Uniform-cost search to ensure every step is greater than or equal
            // to some small positive constant
            return (distance != null && distance > 0) ? distance : 0.1;
        };
    }

    public static string GetResult(string state, MoveToAction action)
    {
        return action.ToLocation;
    }

    public static Func<INode<string, MoveToAction>, double> CreateSLDHeuristicFunction(string goal, Map map)
    {
        return node => GetSLD(node.State, goal, map);
    }

    private static double GetSLD(string loc1, string loc2, Map map)
    {
        double result = 0.0;
        Point2D pt1 = map.GetPosition(loc1);
        Point2D pt2 = map.GetPosition(loc2);
        if (pt1 != null && pt2 != null)
            result = pt1.Distance(pt2);
        return result;
    }
}
