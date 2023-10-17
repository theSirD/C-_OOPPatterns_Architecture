using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class CoolingSystem
{
    public IList<string>? ListOfSupportedSockets { get; private init; }
    public int MaxTDP { get; private init; }
}