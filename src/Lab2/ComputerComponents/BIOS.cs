using System.Collections.Generic;
namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents;

public class BIOS : BaseComputerComponent
{
    public BIOS(string name, string typeOfBios, string ver, IReadOnlyList<string?> supportedCpus)
        : base(name)
    {
        TypeOfBIOS = typeOfBios;
        Version = ver;
        ListOfSuppertedCPUs = supportedCpus;
    }

    public string TypeOfBIOS { get; private init; }
    public string Version { get; private init; }
    public IReadOnlyList<string?> ListOfSuppertedCPUs { get; private init; }
    public BIOS CloneWithNewVersion(string newName, string ver, IReadOnlyList<string?> cpus)
    {
        return new BIOS(newName, TypeOfBIOS, ver, cpus);
    }

    public BIOS CloneWithNewTypeOfBios(string newName, string newType, IReadOnlyList<string?> cpus)
    {
        return new BIOS(newName, newType, Version, cpus);
    }
}