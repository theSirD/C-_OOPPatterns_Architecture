using System;

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
    public override void CanBePlaced(ComputerConfiguration computer)
    {
        if (computer?.MotherBoard is null)
            throw new ArgumentException("Install mother board first");

        if (computer.MotherBoard.HasNetworkModule)
            throw new ArgumentException("Mother board has built-in network module");

        if (computer.MotherBoard.PciLinesAmount < computer.MotherBoard.CurPciLinesAmount + 1)
            throw new ArgumentException("Mother board does not have enough PCIE lines");
    }
}