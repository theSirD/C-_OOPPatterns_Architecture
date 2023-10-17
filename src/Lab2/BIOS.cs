using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class BIOS
{
    public string? TypeOfBIOS { get; private init; }
    public string? Version { get; private init; }
    public IList<string>? ListOfSuppertedCPUs { get; private init; }
}