using System;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents;

public class CPU : BaseRepoItem
{
    public CPU(
        string name,
        double frequencyOfCores,
        int coresAmount,
        string socket,
        bool hasGpu,
        double minMemoryFreq,
        double maxMemoryFreq,
        int tdp,
        int consump)
    : base(name)
    {
        FrequencyOfCores = frequencyOfCores;
        CoresAmount = coresAmount;
        Socket = socket;
        HasGpu = hasGpu;
        MinMemoryFrequency = minMemoryFreq;
        MaxMemoryFrequency = maxMemoryFreq;
        Tdp = tdp;
        PowerConsumptionInWt = consump;
    }

    public double FrequencyOfCores { get; private init; }
    public int CoresAmount { get; private init; }
    public string Socket { get; private init; }
    public bool HasGpu { get; private init; }
    public double MinMemoryFrequency { get; private init; }
    public double MaxMemoryFrequency { get; private init; }
    public int Tdp { get; private init; }
    public int PowerConsumptionInWt { get; private init; }

    public void CanBePlaced(ComputerConfiguration computer)
    {
        if (computer?.Bios is null)
            throw new ArgumentException("Install BIOS first");

        if (!(bool)computer.Bios.ListOfSuppertedCPUs?.Contains(Name))
            throw new ArgumentException("BIOS does not support this CPU");

        if (computer.MotherBoard?.Socket != Socket)
            throw new ArgumentException("Mother board does not support this CPU");
    }

    public CPU CloneWithNewFrequencyBoundaries(string newName, double minFreq, double maxFreq, int tdp, int consump)
    {
        return new CPU(newName, FrequencyOfCores, CoresAmount, Socket, HasGpu, minFreq, maxFreq, tdp, consump);
    }

    public override BaseRepoItem Clone()
    {
        return new CPU(Name, FrequencyOfCores, CoresAmount, Socket, HasGpu, MinMemoryFrequency, MaxMemoryFrequency, Tdp, PowerConsumptionInWt);
    }
}