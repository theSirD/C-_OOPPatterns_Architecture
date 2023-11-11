using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Enums;
using Itmo.ObjectOrientedProgramming.Lab1.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Responses;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class AdventureService
{
    private readonly BaseShip _ship;

    public AdventureService(BaseShip ship)
    {
        _ship = ship;
    }

    public SegmentResults TakeDamageFromSegment(IList<int>? obstacles)
    {
        // change
        SegmentResults result = SegmentResults.Success;

        if (obstacles is null) result = SegmentResults.Success;

        for (int i = 0; i < obstacles?.Count; i++)
        {
            result = _ship.TakeDamage(i, obstacles[i]);
            if (result == SegmentResults.CrewIsDead ||
                result == SegmentResults.ShipIsDestroyed) break;
        }

        return result;
    }

    public FlightResponse CalculateFuelAndTimeForPulseEngine(int length)
    {
        if (_ship.PulseEngine is null) return new FlightResponse(0, 0, SegmentResults.ShipIsLost);
        double time = length / _ship.PulseEngine.Speed;
        double fuelConsumption = time * _ship.PulseEngine.FuelConsumptionInLitersPerSecond;

        if (_ship.PulseEngine.Fuel < fuelConsumption) return new FlightResponse(0, 0, SegmentResults.ShipIsLost);

        return new FlightResponse(time, fuelConsumption, SegmentResults.Success);
    }

    public FlightResponse CalculateFuelAndTimeForJumpEngine(int length)
    {
        if (_ship.JumpEngine is null) return new FlightResponse(0, 0, SegmentResults.ShipIsLost);
        double time = length / _ship.JumpEngine.Speed;

        double fuelConsumption = 0;
        switch (_ship.JumpEngine)
        {
            case JumpEngineA:
                fuelConsumption = time;
                break;
            case JumpEngineO:
                fuelConsumption = time * Math.Log2(time);
                break;
            case JumpEngineG:
                fuelConsumption = time * time;
                break;
        }

        if (_ship.JumpEngine.Fuel < fuelConsumption) return new FlightResponse(0, 0, SegmentResults.ShipIsLost);

        return new FlightResponse(time, fuelConsumption, SegmentResults.Success);
    }
}