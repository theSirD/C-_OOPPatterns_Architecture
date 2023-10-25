using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Storage;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class ComputerConfiguration
{
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
}