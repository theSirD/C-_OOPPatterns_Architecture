using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents;

public class CPU : BaseComputerComponent
{
    public CPU(
        string name,
        double frequencyOfCores,
        int coresAmount,
        string socket,
        bool hasGpu,
        int minMemoryFreq,
        int maxMemoryFreq,
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
    public string? Socket { get; private init; }
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
}