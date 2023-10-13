using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSegments.Environments;

public class DenseFog : BaseEnvironment
{
    private readonly bool[] _isObstacleAllowed;

    public DenseFog(IList<int> obstacles)
        : base(obstacles)
    {
        _isObstacleAllowed = new bool[] { false, false, false, true };
    }
}