using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSegments.Environments;

public class NitrinFog : BaseEnvironment
{
    private readonly bool[] _isObstacleAllowed;

    public NitrinFog(IList<int> obstacles)
        : base(obstacles)
    {
        _isObstacleAllowed = new bool[] { false, false, true, false };
    }
}