using System;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Storage;

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

    public void WithCool(string name)
    {
        var curCool = (CoolingSystem)_repo.Get(name);

        try
        {
            curCool.CanBePlaced(Computer);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }

        Computer.Cool = curCool;
    }

    public void WithCpu(string name)
    {
        var curCpu = (CPU)_repo.Get(name);

        try
        {
            curCpu.CanBePlaced(Computer);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }

        Computer.Cpu = curCpu;
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
        var curNetworkModule = (NetworkModule)_repo.Get(name);

        try
        {
            curNetworkModule.CanBePlaced(Computer);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }

        Computer.Wifi = curNetworkModule;
        if (Computer.MotherBoard is not null) Computer.MotherBoard.CurPciLinesAmount++;
    }

    public void WithDedicatedGpu(string name)
    {
        var curGpu = (DedicatedGPU)_repo.Get(name);

        try
        {
            curGpu.CanBePlaced(Computer);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }

        Computer.DedicatedGpu = curGpu;
        if (Computer.MotherBoard is not null) Computer.MotherBoard.CurPciLinesAmount++;
    }

    public void WithSsd(string name)
    {
        var curSsd = (SSD)_repo.Get(name);

        try
        {
            curSsd.CanBePlaced(Computer);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }

        Computer.Ssd = curSsd;
        if (Computer.MotherBoard is not null)
        {
            if (curSsd.ConnectionType == "PCIE") Computer.MotherBoard.CurPciLinesAmount++;
            else Computer.MotherBoard.CurSataPortsAmount++;
        }
    }

    public ComputerConfiguration Build()
    {
        return Computer;
    }
}