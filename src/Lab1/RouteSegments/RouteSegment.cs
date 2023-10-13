using Itmo.ObjectOrientedProgramming.Lab1.Environments;

namespace Itmo.ObjectOrientedProgramming.Lab1.Route;

public class RouteSegment
{
    protected RouteSegment(BaseEnvironment environment, int length)
    {
        Environment = environment;
        Length = length;
    }

    private BaseEnvironment? Environment { get; set; }
    private int Length { get; set; }
}