using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Responses;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSegments.Environments;

public abstract class BaseEnvironment
{
    private readonly bool[] _isObstacleAllowed = new bool[] { false, false, false, false };

    protected BaseEnvironment(IList<int>? obstacles)
    {
        ObstaclesList = obstacles;
    }

    public IList<int>? ObstaclesList { get; private set; }

    public EnvironmentValidationResponse ValidateObstacles()
    {
        if (ObstaclesList is null) return EnvironmentValidationResponse.EnvObstaclesIsNull;

        for (int i = 0; i < _isObstacleAllowed.Length; i++)
        {
            if (!_isObstacleAllowed[i] && ObstaclesList[i] != 0) return EnvironmentValidationResponse.EnvIsInvalid;

            if (ObstaclesList[i] < 0) return EnvironmentValidationResponse.EnvIsInvalid;
        }

        return EnvironmentValidationResponse.EnvIsValid;
    }
}