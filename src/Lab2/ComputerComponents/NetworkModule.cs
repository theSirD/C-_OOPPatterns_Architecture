namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents;

public class NetworkModule : BaseComputerComponent
{
    public NetworkModule(string name, double version, bool hasBluetooth, int pcieVer, int consump)
    : base(name)
    {
        Version = version;
        HasBluetooth = hasBluetooth;
        PcieVersion = pcieVer;
        PowerConsumptionInWt = consump;
    }

    public double Version { get; private set; }
    public bool HasBluetooth { get; private set; }
    public int PcieVersion { get; private init; }
    public int PowerConsumptionInWt { get; private init; }
}