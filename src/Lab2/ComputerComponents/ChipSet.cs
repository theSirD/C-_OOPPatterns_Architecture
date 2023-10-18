namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents;

public class ChipSet : BaseComputerComponent
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
}