using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.RouteSegments;
using Itmo.ObjectOrientedProgramming.Lab1.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Adventure
{
    private readonly BaseShip _ship;
    private readonly IList<RouteSegment>? _route;
    private readonly AdventureService _adventureService;

    public Adventure(BaseShip ship, IList<RouteSegment> route)
    {
        _ship = ship;
        _route = route;
        _adventureService = new AdventureService(_ship);
    }

    public void StartAdventure()
    {
        if (_route is null) return;

        foreach (RouteSegment segment in _route)
        {
            // Replace with proper validation
            if (segment.Environment is null) return;
            _adventureService.TakeDamageFromSegment(segment.Environment.ObstaclesList);
        }
    }
}