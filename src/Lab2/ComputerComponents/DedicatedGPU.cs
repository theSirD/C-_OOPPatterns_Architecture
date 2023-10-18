namespace Itmo.ObjectOrientedProgramming.Lab2;

public class DedicatedGPU : ComputerComponent
{
    public DedicatedGPU(string name, double w, double h, int vram, int pcie, double freq, int consump)
        : base(name)
    {
        Width = w;
        Height = h;
        VRAMAmount = vram;
        PcieVersion = pcie;
        Frequency = freq;
        PowerConsumptionInWt = consump;
    }

    public double Width { get; set; }
    public double Height { get; init; }
    public int VRAMAmount { get; init; }
    public int PcieVersion { get; init; }
    public double Frequency { get; init; }
    public int PowerConsumptionInWt { get; init; }
}