namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents;

public class MotherBoard : BaseComputerComponent
{
    public MotherBoard(
        string name,
        string socket,
        int pciCount,
        int sataCount,
        ChipSet? chipSet,
        int ddrStandard,
        int ddrSlotsCount,
        bool hasNetworkModule)
        : base(name)
    {
        Socket = socket;
        PciLinesAmount = pciCount;
        SataPortsAmount = sataCount;
        ChipSet = chipSet;
        SupportedDdrStandard = ddrStandard;
        DdrSlotsAmount = ddrSlotsCount;
        HasNetworkModule = hasNetworkModule;
    }

    public string? Socket { get; private init; }
    public int PciLinesAmount { get; private init; }
    public int SataPortsAmount { get; private init; }
    public ChipSet? ChipSet { get; private init; }
    public int SupportedDdrStandard { get; private init; }
    public int DdrSlotsAmount { get; private init; }
    public bool HasNetworkModule { get; private init; }
}