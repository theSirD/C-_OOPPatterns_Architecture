using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSegments.Environments;

public class RegularSpace : BaseEnvironment
{
    private readonly bool[] _isObstacleAllowed;

    public RegularSpace(IList<int> obstacles)
        : base(obstacles)
    {
        _isObstacleAllowed = new bool[] { true, true, false, false };
    }
}