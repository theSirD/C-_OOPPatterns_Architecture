using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Responses;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSegments.Environments;

public abstract class BaseEnvironment
{
    protected BaseEnvironment(IList<int>? obstacles)
    {
        ObstaclesList = obstacles;
    }

    public IList<int>? ObstaclesList { get; private set; }

    public abstract EnvironmentValidationResponse ValidateObstacles();
}