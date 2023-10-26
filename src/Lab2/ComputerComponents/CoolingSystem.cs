using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents;

public class CoolingSystem : BaseComputerComponent
{
    public CoolingSystem(string name, IList<string?> supportedSockets, int tdp, int width, int height)
    : base(name)
    {
        ListOfSupportedSockets = supportedSockets;
        MaxTDP = tdp;
        WidthInSm = width;
        HeightInSm = height;
    }

    public IList<string?>? ListOfSupportedSockets { get; private init; }
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
}