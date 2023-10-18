namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents;

public class RAM : BaseComputerComponent
{
    public RAM(string name, int mmrySize, int ddrStandard, int consump)
    : base(name)
    {
        MemorySize = mmrySize;
        DdrStandard = ddrStandard;
        PowerConsumptionInWt = consump;
    }

    public int MemorySize { get; private init; }
    public int DdrStandard { get; private init; }
    public int PowerConsumptionInWt { get; private init; }
}