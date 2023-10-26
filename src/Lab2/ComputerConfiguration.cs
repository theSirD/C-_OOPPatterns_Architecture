using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Storage;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class ComputerConfiguration : BaseRepoItem
{
    public ComputerConfiguration(string name)
    : base(name) { }
    public ComputerConfiguration(
        string name,
        BIOS? bios,
        CoolingSystem? cooler,
        CPU? cpu,
        MotherBoard? motherBoard,
        PCCase? pcCase,
        PowerPack? powerPack,
        RAM? ram,
        XMPProfile? xmp,
        NetworkModule? networkModule,
        DedicatedGPU? dedicatedGpu,
        HDD? hdd,
        SSD? ssd)
        : base(name)
    {
        Bios = bios;
        Cool = cooler;
        MotherBoard = motherBoard;
        Cpu = cpu;
        ComputerCase = pcCase;
        PowerPack = powerPack;
        Ram = ram;
        Xmp = xmp;
        Wifi = networkModule;
        DedicatedGpu = dedicatedGpu;
        Hdd = hdd;
        Ssd = ssd;
    }

    public BIOS? Bios { get; internal set; }
    public CoolingSystem? Cool { get; internal set; }
    public CPU? Cpu { get; internal set; }
    public MotherBoard? MotherBoard { get; internal set; }
    public PCCase? ComputerCase { get; internal set; }
    public PowerPack? PowerPack { get; internal set; }
    public RAM? Ram { get; internal set; }
    public XMPProfile? Xmp { get; internal set; }
    public NetworkModule? Wifi { get; internal set; }
    public DedicatedGPU? DedicatedGpu { get; internal set; }

    public HDD? Hdd { get; internal set; }
    public SSD? Ssd { get; internal set; }

    public override BaseRepoItem Clone()
    {
        return new ComputerConfiguration(
            Name,
            Bios,
            Cool,
            Cpu,
            MotherBoard,
            ComputerCase,
            PowerPack,
            Ram,
            Xmp,
            Wifi,
            DedicatedGpu,
            Hdd,
            Ssd);
    }
}