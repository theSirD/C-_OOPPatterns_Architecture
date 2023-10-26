using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents;

public class DedicatedGPU : BaseComputerComponent
{
    public DedicatedGPU(string name, double w, double h, int vram, int pcieVersion, double freq, int consump)
        : base(name)
    {
        WidthInSm = w;
        HeightInSm = h;
        VRAMAmount = vram;
        PcieVersion = pcieVersion;
        FrequencyInGhz = freq;
        PowerConsumptionInWt = consump;
    }

    public double WidthInSm { get; set; }
    public double HeightInSm { get; init; }
    public int VRAMAmount { get; init; }
    public int PcieVersion { get; init; }
    public double FrequencyInGhz { get; init; }
    public int PowerConsumptionInWt { get; init; }

    public void CanBePlaced(ComputerConfiguration computer)
    {
        if (computer?.MotherBoard is null)
            throw new ArgumentException("Install mother board first");

        if (computer.MotherBoard.PciLinesAmount < computer.MotherBoard.CurPciLinesAmount + 1)
            throw new ArgumentException("Mother board does not have enough PCIE lines");
    }
}