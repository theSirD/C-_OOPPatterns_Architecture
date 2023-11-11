using Itmo.ObjectOrientedProgramming.Lab2.CustomExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents;

public class NetworkModule : BaseRepoItem
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
    public void CanBePlaced(ComputerConfiguration computer)
    {
        if (computer?.MotherBoard is null)
            throw new BuildLacksRequiredComponentsException("Install mother board first");

        if (computer.MotherBoard.HasNetworkModule)
            throw new ComponentIsNotSupportedException("Mother board has built-in network module");

        if (computer.MotherBoard.PcieVersion < PcieVersion)
            throw new ComponentIsNotSupportedException("Mother board's PCIE is too old for this Wi-Fi module");

        if (computer.MotherBoard.PciLinesAmount < computer.MotherBoard.CurPciLinesAmount + 1)
            throw new NotEnoughPortsException("Mother board does not have enough PCIE lines");
    }

    public NetworkModule CloneWithNewPcieVersion(string newName, int pcieVer)
    {
        return new NetworkModule(newName, Version, HasBluetooth, pcieVer, PowerConsumptionInWt);
    }

    public override BaseRepoItem Clone()
    {
        return new NetworkModule(Name, Version, HasBluetooth, PcieVersion, PowerConsumptionInWt);
    }
}