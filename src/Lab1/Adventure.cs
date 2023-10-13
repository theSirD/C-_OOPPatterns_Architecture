using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Enums;
using Itmo.ObjectOrientedProgramming.Lab1.PulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Responses;
using Itmo.ObjectOrientedProgramming.Lab1.RouteSegments;
using Itmo.ObjectOrientedProgramming.Lab1.RouteSegments.Environments;
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

    public FlightResponse StartAdventure()
    {
        // change
        if (_route is null) return new FlightResponse(0, 0, SegmentResults.Success);

        SegmentResults result;
        foreach (RouteSegment segment in _route)
        {
            // Replace with proper validation
            if (segment.Environment is null) return new FlightResponse(0, 0, SegmentResults.Success);
            result = _adventureService.TakeDamageFromSegment(segment.Environment.ObstaclesList);

            if (result == SegmentResults.ShipIsDestroyed || result == SegmentResults.CrewIsDead)
                return new FlightResponse(0, 0, SegmentResults.Success);
        }

        double totalTime = 0;
        double totalFuelConsumption = 0;
        FlightResponse response;
        foreach (RouteSegment segment in _route)
        {
            response = ChooseEngine(segment);
            if (response.SegmentResult == SegmentResults.ShipIsLost)
                return new FlightResponse(0, 0, SegmentResults.ShipIsLost);
            totalTime += response.TimeResult;
            totalFuelConsumption += response.FuelResult;
        }

        return new FlightResponse(totalTime, totalFuelConsumption, SegmentResults.Success);
    }

    private FlightResponse ChooseEngine(RouteSegment segment)
    {
        switch (segment.Environment)
        {
            case RegularSpace:
                return _adventureService.CalculateFuelAndTimeForPulseEngine(segment.Length);

            case NitrinFog:
                if (_ship.PulseEngine is not PulseEngineE)
                    return new FlightResponse(0, 0, SegmentResults.ShipIsLost);
                return _adventureService.CalculateFuelAndTimeForPulseEngine(segment.Length);

            case DenseFog:
                return _adventureService.CalculateFuelAndTimeForJumpEngine(segment.Length);
        }

        return new FlightResponse(0, 0, SegmentResults.ShipIsLost);
    }
}