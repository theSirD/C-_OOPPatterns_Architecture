namespace Itmo.ObjectOrientedProgramming.Lab2;

public class CPU
{
    public double FrequencyOfCores { get; private init; }
    public int CoresAmount { get; private init; }
    public string? Socket { get; private init; }
    public bool HasGPU { get; private init; }
    public double MinMemoryFrequency { get; private init; }
    public double MaxMemoryFrequency { get; private init; }
    public int TDP { get; private init; }
    public int PowerConsumptionInWt { get; private init; }
}