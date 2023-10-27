using Itmo.ObjectOrientedProgramming.Lab2.CustomExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents;

public class RAM : BaseRepoItem
{
    public RAM(string name, int mmrySize, int ddrStandard, int consump, double freq)
    : base(name)
    {
        MemorySize = mmrySize;
        DdrStandard = ddrStandard;
        PowerConsumptionInWt = consump;
        Frequency = freq;
    }

    public int MemorySize { get; private init; }
    public int DdrStandard { get; private init; }
    public int PowerConsumptionInWt { get; private init; }
    public double Frequency { get; private init; }
    public void CanBePlaced(ComputerConfiguration computer)
    {
        if (computer?.MotherBoard is null)
            throw new BuildLacksRequiredComponentsException("Install mother board first");

        if (computer?.MotherBoard.MinMemoryFrequency > Frequency)
            throw new ComponentIsNotSupportedException("This RAM is too slow");

        if (computer?.MotherBoard.SupportedDdrStandard < DdrStandard)
            throw new ComponentIsNotSupportedException("Mother board does not support this DDR standard");
    }

    public RAM CloneWithNewFrequency(string newName, double freq)
    {
        return new RAM(newName, MemorySize, DdrStandard, PowerConsumptionInWt, freq);
    }

    public override BaseRepoItem Clone()
    {
        return new RAM(Name, MemorySize, DdrStandard, PowerConsumptionInWt, Frequency);
    }
}