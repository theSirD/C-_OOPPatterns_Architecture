namespace Itmo.ObjectOrientedProgramming.Lab2;

public class MotherBoard
{
    public string? Socket { get; private init; }
    public int PCILinesAmount { get; private init; }
    public int SATAPortsAmount { get; private init; }
    public ChipSet? ChipSet { get; private init; }
    public int SupportedDDRStandard { get; private init; }
    public int DDRSlotsAmount { get; private init; }
    public bool HasNetworkModule { get; private init; }
}