using System;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Storage;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;

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
        var curRam = (RAM)_repo.Get(name);

        try
        {
            curRam.CanBePlaced(Computer);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }

        Computer.Ram = curRam;
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
            if (curSsd.ConnectionType == SSDConnectionType.PCIE) Computer.MotherBoard.CurPciLinesAmount++;
            else Computer.MotherBoard.CurSataPortsAmount++;
        }
    }

    public void WithHdd(string name)
    {
        Computer.Hdd = (HDD)_repo.Get(name);
    }

    public ComputerConfiguration Build()
    {
        if (Computer.Hdd is null && Computer.Ssd is null)
            throw new ArgumentException("Configuration does not have a storage");

        if (Computer.MotherBoard is null || Computer.Cpu is null || Computer.Bios is null ||
            Computer.Cool is null || Computer.Ram is null || Computer.PowerPack is null ||
            Computer.ComputerCase is null)
            throw new ArgumentException("Configuration does not have one (or more) required components");

        switch (Computer.ComputerCase.SupportedFormOfMotherBoard)
        {
            case MotherBoardFormFactors.MicroATX:
                if (Computer.MotherBoard.FormFactor == MotherBoardFormFactors.ATX)
                    throw new ArgumentException("Computer case does not support form factor of mother boards chosen");
                break;

            case MotherBoardFormFactors.MiniATX:
                if (Computer.MotherBoard.FormFactor == MotherBoardFormFactors.ATX || Computer.MotherBoard.FormFactor == MotherBoardFormFactors.MicroATX)
                    throw new ArgumentException("Computer case does not support form factor of mother boards chosen");
                break;

            case MotherBoardFormFactors.NanoATX:
                if (Computer.MotherBoard.FormFactor == MotherBoardFormFactors.ATX ||
                    Computer.MotherBoard.FormFactor == MotherBoardFormFactors.MicroATX ||
                    Computer.MotherBoard.FormFactor == MotherBoardFormFactors.NanoATX)
                    throw new ArgumentException("Computer case does not support form factor of mother boards chosen");
                break;
        }

        if (!Computer.Cpu.HasGpu && Computer.DedicatedGpu is null)
            throw new ArgumentException("Configuration does not have a GPU");

        if (Computer.Cool.WidthInSm + (Computer.DedicatedGpu is null ? 0 : Computer.DedicatedGpu.WidthInSm) > Computer.ComputerCase.WidthInSm)
            throw new ArgumentException("Components are to wide for this computer case");

        if (Computer.Cool.HeightInSm + (Computer.DedicatedGpu is null ? 0 : Computer.DedicatedGpu.HeightInSm) > Computer.ComputerCase.HeightInSm)
            throw new ArgumentException("Components are to tall for this computer case");

        if (Computer.Cpu.Tdp > Computer.Cool.MaxTDP)
            throw new ArgumentException("Cooling system is not good enough");

        if (Computer.Cpu.PowerConsumptionInWt + Computer.Ram.PowerConsumptionInWt +
            (Computer.DedicatedGpu is null ? 0 : Computer.DedicatedGpu.PowerConsumptionInWt)
            + (Computer.Ssd is null ? 0 : Computer.Ssd.PowerConsumptionInWt) +
            (Computer.Hdd is null ? 0 : Computer.Hdd.PowerConsumptionInWt) > Computer.PowerPack.PeakLoadInWt)
            throw new ArgumentException("Power pack is not good enough");

        return Computer;
    }
}