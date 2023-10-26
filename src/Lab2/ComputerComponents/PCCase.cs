using Itmo.ObjectOrientedProgramming.Lab2.Enums;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents;

public class PCCase : BaseRepoItem
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

    public PCCase CloneWithNewSize(string newName, int width, int height)
    {
        return new PCCase(newName, width, height, SupportedFormOfMotherBoard);
    }

    public override BaseRepoItem Clone()
    {
        return new PCCase(Name, WidthInSm, HeightInSm, SupportedFormOfMotherBoard);
    }
}