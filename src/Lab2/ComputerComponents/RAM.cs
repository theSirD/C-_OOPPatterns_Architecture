using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents;

public class RAM : BaseComputerComponent
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
            throw new ArgumentException("Install mother board first");

        if (computer?.MotherBoard.ChipSet?.MinMemoryFrequency > Frequency)
            throw new ArgumentException("This RAM is too slow");

        if (computer?.MotherBoard.SupportedDdrStandard < DdrStandard)
            throw new ArgumentException("Mother board does not support this DDR standard");
    }
}