using System;
using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents;

public class CoolingSystem : BaseRepoItem
{
    public CoolingSystem(string name, IReadOnlyList<string?> supportedSockets, int tdp, int width, int height)
    : base(name)
    {
        ListOfSupportedSockets = supportedSockets;
        MaxTDP = tdp;
        WidthInSm = width;
        HeightInSm = height;
    }

    public IReadOnlyList<string?> ListOfSupportedSockets { get; private init; }
    public int MaxTDP { get; private init; }
    public int WidthInSm { get; private init; }
    public int HeightInSm { get; private init; }

    public void CanBePlaced(ComputerConfiguration computer)
    {
        if (computer?.MotherBoard is null)
            throw new ArgumentException("Install mother board first");

        if (!(bool)ListOfSupportedSockets?.Contains(computer?.MotherBoard.Socket))
            throw new ArgumentException("Mother board does not support this cooling system");
    }

    public CoolingSystem CloneWithNewSize(string newName, int tdp, int width, int height)
    {
        return new CoolingSystem(newName, ListOfSupportedSockets, tdp, width, height);
    }

    public override BaseRepoItem Clone()
    {
        return new CoolingSystem(Name, ListOfSupportedSockets, MaxTDP, WidthInSm, HeightInSm);
    }
}