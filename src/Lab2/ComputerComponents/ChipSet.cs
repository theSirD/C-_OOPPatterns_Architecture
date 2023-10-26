namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents;

public class ChipSet : BaseRepoItem
{
    public ChipSet(string name, double minFreq, double maxFreq, bool isXmpSupported)
        : base(name)
    {
        MinMemoryFrequency = minFreq;
        MaxMemoryFrequency = maxFreq;
        XMPSupport = isXmpSupported;
    }

    public double MinMemoryFrequency { get; private init; }
    public double MaxMemoryFrequency { get; private init; }
    public bool XMPSupport { get; private init; }

    public ChipSet CloneWithNewFrequencyBoundaries(string newName, double minFreq, double maxFreq)
    {
        return new ChipSet(newName, minFreq, maxFreq, XMPSupport);
    }

    public ChipSet CloneWithNewXmpSupport(string newName, bool isXmpSupported)
    {
        return new ChipSet(newName, MinMemoryFrequency, MaxMemoryFrequency, isXmpSupported);
    }

    public override BaseRepoItem Clone()
    {
        return new ChipSet(Name, MinMemoryFrequency, MaxMemoryFrequency, XMPSupport);
    }
}