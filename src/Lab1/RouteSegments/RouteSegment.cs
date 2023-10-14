using Itmo.ObjectOrientedProgramming.Lab1.RouteSegments.Environments;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSegments;

public class RouteSegment
{
    public RouteSegment(BaseEnvironment environment, int length)
    {
        Environment = environment;
        Length = length;
    }

    public BaseEnvironment? Environment { get; private set; }
    public int Length { get; private set; }
}