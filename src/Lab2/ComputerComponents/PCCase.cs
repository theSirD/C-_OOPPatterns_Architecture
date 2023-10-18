namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents;

public class PCCase : BaseComputerComponent
{
    public PCCase(string name, int widthOfGpu, int heightOfGpu, string form)
    : base(name)
    {
        MaxWidthOfGPUInSm = widthOfGpu;
        MaxHeightOfGPUInSm = heightOfGpu;
        SupportedFormOfMotherBoard = form;
    }

    public double MaxWidthOfGPUInSm { get; private init; }
    public double MaxHeightOfGPUInSm { get; private init; }
    public string? SupportedFormOfMotherBoard { get; private init; }
}