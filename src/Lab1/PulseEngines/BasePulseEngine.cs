namespace Itmo.ObjectOrientedProgramming.Lab1.PulseEngines;

public abstract class BasePulseEngine
{
    public double Speed { get; protected init; }
    public int FuelConsumptionInLitersPerSecond { get; protected init; }
    public int Fuel { get; protected init; }
}