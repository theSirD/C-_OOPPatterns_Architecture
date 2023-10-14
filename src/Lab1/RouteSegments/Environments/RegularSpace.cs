using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Responses;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSegments.Environments;

public class RegularSpace : BaseEnvironment
{
    private readonly bool[] _isObstacleAllowed;

    public RegularSpace(IList<int> obstacles)
        : base(obstacles)
    {
        _isObstacleAllowed = new bool[] { true, true, false, false };
    }

    public override EnvironmentValidationResponse ValidateObstacles()
    {
        if (ObstaclesList is null) return EnvironmentValidationResponse.EnvIsInvalid;

        for (int i = 0; i < _isObstacleAllowed.Length; i++)
        {
            if (!_isObstacleAllowed[i] && ObstaclesList[i] != 0) return EnvironmentValidationResponse.EnvIsInvalid;

            if (ObstaclesList[i] < 0) return EnvironmentValidationResponse.EnvIsInvalid;
        }

        return EnvironmentValidationResponse.EnvIsValid;
    }
}