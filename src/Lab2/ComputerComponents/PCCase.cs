using Itmo.ObjectOrientedProgramming.Lab2.Enums;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents;

public class PCCase : BaseComputerComponent
{
    public PCCase(string name, int width, int height, MotherBoardFormFactors form)
    : base(name)
    {
        WidthInSm = width;
        HeightInSm = height;
        SupportedFormOfMotherBoard = form;
    }

    public int WidthInSm { get; private init; }
    public int HeightInSm { get; private init; }
    public MotherBoardFormFactors SupportedFormOfMotherBoard { get; private init; }
}