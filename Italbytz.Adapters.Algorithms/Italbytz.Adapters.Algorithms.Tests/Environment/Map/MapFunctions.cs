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
}
