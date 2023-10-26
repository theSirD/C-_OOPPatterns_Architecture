using Itmo.ObjectOrientedProgramming.Lab2.Enums;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents;

public class MotherBoard : BaseRepoItem
{
    public MotherBoard(
        string name,
        string socket,
        int pciCount,
        int sataCount,
        BaseRepoItem chipSet,
        int ddrStandard,
        int ddrSlotsCount,
        bool hasNetworkModule,
        int pcieVersion,
        MotherBoardFormFactors form)
        : base(name)
    {
        Socket = socket;
        PciLinesAmount = pciCount;
        SataPortsAmount = sataCount;
        ChipSet = (ChipSet)chipSet;
        SupportedDdrStandard = ddrStandard;
        DdrSlotsAmount = ddrSlotsCount;
        HasNetworkModule = hasNetworkModule;
        PcieVersion = pcieVersion;
        FormFactor = form;

        CurPciLinesAmount = 0;
        CurSataPortsAmount = 0;
    }

    public string Socket { get; private init; }
    public int PciLinesAmount { get; private init; }
    public int CurPciLinesAmount { get; set; }
    public int SataPortsAmount { get; private init; }

    public int CurSataPortsAmount { get; set; }
    public ChipSet ChipSet { get; private init; }
    public int SupportedDdrStandard { get; private init; }
    public int DdrSlotsAmount { get; private init; }
    public bool HasNetworkModule { get; private init; }
    public int PcieVersion { get; private init; }
    public MotherBoardFormFactors FormFactor { get; private init; }

    public MotherBoard CloneWithNewConnectionPorts(string newName, int pciLinesAmount, int sataPortsAmount, int ddrSlotsAmount)
    {
        return new MotherBoard(newName, Socket, pciLinesAmount, sataPortsAmount, ChipSet.Clone(), SupportedDdrStandard, ddrSlotsAmount, HasNetworkModule, PcieVersion, FormFactor);
    }

    public override BaseRepoItem Clone()
    {
        return new MotherBoard(Name, Socket, PciLinesAmount, SataPortsAmount, ChipSet.Clone(), SupportedDdrStandard, DdrSlotsAmount, HasNetworkModule, PcieVersion, FormFactor);
    }
}