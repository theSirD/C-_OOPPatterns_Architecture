namespace Itmo.ObjectOrientedProgramming.Lab2;

public class DedicatedGPU
{
    public double Width { get; private init; }
    public double Height { get; private init; }
    public int VRAM { get; private init; }
    public int PcieVersion { get; private init; }
    public double Frequency { get; private init; }
    public int PowerConsumptionInWt { get; private init; }
}