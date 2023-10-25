using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class ComputerBuilder
{
    private ComponentsRepo _repo = ComponentsRepo.Current;

    public ComputerConfiguration Computer { get; private set; } = new ComputerConfiguration();

    public void Reset()
    {
        Computer = new ComputerConfiguration();
    }

    public void WithBios(string name)
    {
        Computer.Bios = (BIOS)_repo.Get(name);
    }

    public void WithChipset(string name)
    {
        Computer.Chipset = (ChipSet)_repo.Get(name);
    }

    public void WithCool(string name)
    {
        Computer.Cool = (CoolingSystem)_repo.Get(name);
    }

    public void WithCpu(string name)
    {
        Computer.Cpu = (CPU)_repo.Get(name);
    }

    public void WithMotherBoard(string name)
    {
        Computer.MotherBoard = (MotherBoard)_repo.Get(name);
    }

    public void WithComputerCase(string name)
    {
        Computer.ComputerCase = (PCCase)_repo.Get(name);
    }

    public void WithPowerPack(string name)
    {
        Computer.PowerPack = (PowerPack)_repo.Get(name);
    }

    public void WithRam(string name)
    {
        Computer.Ram = (RAM)_repo.Get(name);
    }

    public void WithXmp(string name)
    {
        Computer.Xmp = (XMPProfile)_repo.Get(name);
    }

    public void WithWifi(string name)
    {
        Computer.Wifi = (NetworkModule)_repo.Get(name);
    }

    public void WithDedicatedGpu(string name)
    {
        Computer.DedicatedGpu = (DedicatedGPU)_repo.Get(name);
    }

    public ComputerConfiguration Build()
    {
        return Computer;
    }
}