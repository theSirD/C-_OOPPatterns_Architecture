using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents;

public class CoolingSystem : BaseComputerComponent
{
    public CoolingSystem(string name, IList<string> supportedSockets, int tdp)
    : base(name)
    {
        ListOfSupportedSockets = supportedSockets;
        MaxTDP = tdp;
    }

    public IList<string>? ListOfSupportedSockets { get; private init; }
    public int MaxTDP { get; private init; }
}