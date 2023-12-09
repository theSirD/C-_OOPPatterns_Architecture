using Itmo.ObjectOrientedProgramming.Lab2.Enums;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents;

public class MotherBoard : BaseRepoItem
{
    public MotherBoard(
        string name,
        string socket,
        int pciCount,
        int sataCount,
        int ddrStandard,
        int ddrSlotsCount,
        bool hasNetworkModule,
        int pcieVersion,
        MotherBoardFormFactors form,
        double minFrequency,
        double maxFrequency,
        bool isXmpSupported)
        : base(name)
    {
        Socket = socket;
        PciLinesAmount = pciCount;
        SataPortsAmount = sataCount;
        SupportedDdrStandard = ddrStandard;
        DdrSlotsAmount = ddrSlotsCount;
        HasNetworkModule = hasNetworkModule;
        PcieVersion = pcieVersion;
        FormFactor = form;
        MinMemoryFrequency = minFrequency;
        MaxMemoryFrequency = maxFrequency;
        IsXmpSupported = isXmpSupported;

        CurPciLinesAmount = 0;
        CurSataPortsAmount = 0;
    }

    public string Socket { get; private init; }
    public int PciLinesAmount { get; private init; }
    public int CurPciLinesAmount { get; set; }
    public int SataPortsAmount { get; private init; }

    public int CurSataPortsAmount { get; set; }
    public int SupportedDdrStandard { get; private init; }
    public int DdrSlotsAmount { get; private init; }
    public bool HasNetworkModule { get; private init; }
    public int PcieVersion { get; private init; }
    public MotherBoardFormFactors FormFactor { get; private init; }

    public double MinMemoryFrequency { get;  private init; }

    public double MaxMemoryFrequency { get;  private init; }

    public bool IsXmpSupported { get;  private init; }

    public MotherBoard CloneWithNewConnectionPorts(string newName, int pciLinesAmount, int sataPortsAmount, int ddrSlotsAmount)
    {
        return new MotherBoard(newName, Socket, pciLinesAmount, sataPortsAmount, SupportedDdrStandard, ddrSlotsAmount, HasNetworkModule, PcieVersion, FormFactor, MinMemoryFrequency, MaxMemoryFrequency, IsXmpSupported);
    }

    public override BaseRepoItem Clone()
    {
        return new MotherBoard(Name, Socket, PciLinesAmount, SataPortsAmount, SupportedDdrStandard, DdrSlotsAmount, HasNetworkModule, PcieVersion, FormFactor, MinMemoryFrequency, MaxMemoryFrequency, IsXmpSupported);
    }
}