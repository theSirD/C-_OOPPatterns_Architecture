using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.PulseEngines;

public class PulseEngineE : BasePulseEngine
{
    private readonly int _maxFlyTime;

    public PulseEngineE()
    {
        FuelConsumptionInLitersPerSecond = 15;
        Fuel = 75;
        _maxFlyTime = Fuel / FuelConsumptionInLitersPerSecond;
        Speed = Math.Exp(_maxFlyTime);
    }
}