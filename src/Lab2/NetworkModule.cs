namespace Itmo.ObjectOrientedProgramming.Lab2;

public class NetworkModule
{
    public double Version { get; private set; }
    public bool HasBluetooth { get; private set; }
    public int PcieVersion { get; private init; }
    public int PowerConsumptionInWt { get; private init; }
}