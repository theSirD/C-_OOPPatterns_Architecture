using System;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Storage;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class ComputerBuilder
{
    private ComponentsRepo _repo = ComponentsRepo.Current;
    private ComputerConfiguration _computer;

    public ComputerBuilder(string name)
    {
        _computer = new ComputerConfiguration(name);
    }

    public ComputerBuilder(ComputerConfiguration computer)
    {
        if (computer is null)
            throw new ArgumentException("Passed null instead of computer");
        _computer = (ComputerConfiguration)computer.Clone();
    }

    public void Reset(string name)
    {
        _computer = new ComputerConfiguration(name);
    }

    public void WithBios(string name)
    {
        _computer.Bios = (BIOS)_repo.Get(name);
    }

    public void WithCool(string name)
    {
        var curCool = (CoolingSystem)_repo.Get(name);

        try
        {
            curCool.CanBePlaced(_computer);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }

        _computer.Cool = curCool;
    }

    public void WithCpu(string name)
    {
        var curCpu = (CPU)_repo.Get(name);

        try
        {
            curCpu.CanBePlaced(_computer);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }

        _computer.Cpu = curCpu;
    }

    public void WithMotherBoard(string name)
    {
        _computer.MotherBoard = (MotherBoard)_repo.Get(name);
    }

    public void WithComputerCase(string name)
    {
        _computer.ComputerCase = (PCCase)_repo.Get(name);
    }

    public void WithPowerPack(string name)
    {
        _computer.PowerPack = (PowerPack)_repo.Get(name);
    }

    public void WithRam(string name)
    {
        var curRam = (RAM)_repo.Get(name);

        try
        {
            curRam.CanBePlaced(_computer);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }

        _computer.Ram = curRam;
    }

    public void WithXmp(string name)
    {
        _computer.Xmp = (XMPProfile)_repo.Get(name);
    }

    public void WithWifi(string name)
    {
        var curNetworkModule = (NetworkModule)_repo.Get(name);

        try
        {
            curNetworkModule.CanBePlaced(_computer);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }

        _computer.Wifi = curNetworkModule;
        if (_computer.MotherBoard is not null) _computer.MotherBoard.CurPciLinesAmount++;
    }

    public void WithDedicatedGpu(string name)
    {
        var curGpu = (DedicatedGPU)_repo.Get(name);

        try
        {
            curGpu.CanBePlaced(_computer);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }

        _computer.DedicatedGpu = curGpu;
        if (_computer.MotherBoard is not null) _computer.MotherBoard.CurPciLinesAmount++;
    }

    public void WithSsd(string name)
    {
        var curSsd = (SSD)_repo.Get(name);

        try
        {
            curSsd.CanBePlaced(_computer);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }

        _computer.Ssd = curSsd;
        if (_computer.MotherBoard is not null)
        {
            if (curSsd.ConnectionType == SSDConnectionType.PCIE) _computer.MotherBoard.CurPciLinesAmount++;
            else _computer.MotherBoard.CurSataPortsAmount++;
        }
    }

    public void WithHdd(string name)
    {
        _computer.Hdd = (HDD)_repo.Get(name);
    }

    public ComputerConfiguration Build()
    {
        if (_computer.Hdd is null && _computer.Ssd is null)
            throw new ArgumentException("Configuration does not have a storage");

        if (_computer.MotherBoard is null || _computer.Cpu is null || _computer.Bios is null ||
            _computer.Cool is null || _computer.Ram is null || _computer.PowerPack is null ||
            _computer.ComputerCase is null)
            throw new ArgumentException("Configuration does not have one (or more) required components");

        switch (_computer.ComputerCase.SupportedFormOfMotherBoard)
        {
            case MotherBoardFormFactors.MicroATX:
                if (_computer.MotherBoard.FormFactor == MotherBoardFormFactors.ATX)
                    throw new ArgumentException("Computer case does not support form factor of mother boards chosen");
                break;

            case MotherBoardFormFactors.MiniATX:
                if (_computer.MotherBoard.FormFactor == MotherBoardFormFactors.ATX || _computer.MotherBoard.FormFactor == MotherBoardFormFactors.MicroATX)
                    throw new ArgumentException("Computer case does not support form factor of mother boards chosen");
                break;

            case MotherBoardFormFactors.NanoATX:
                if (_computer.MotherBoard.FormFactor == MotherBoardFormFactors.ATX ||
                    _computer.MotherBoard.FormFactor == MotherBoardFormFactors.MicroATX ||
                    _computer.MotherBoard.FormFactor == MotherBoardFormFactors.NanoATX)
                    throw new ArgumentException("Computer case does not support form factor of mother boards chosen");
                break;
        }

        if (!_computer.Cpu.HasGpu && _computer.DedicatedGpu is null)
            throw new ArgumentException("Configuration does not have a GPU");

        if (_computer.Cool.WidthInSm + (_computer.DedicatedGpu is null ? 0 : _computer.DedicatedGpu.WidthInSm) > _computer.ComputerCase.WidthInSm)
            throw new ArgumentException("Components are to wide for this computer case");

        if (_computer.Cool.HeightInSm + (_computer.DedicatedGpu is null ? 0 : _computer.DedicatedGpu.HeightInSm) > _computer.ComputerCase.HeightInSm)
            throw new ArgumentException("Components are to tall for this computer case");

        if (_computer.Cpu.Tdp > _computer.Cool.MaxTDP)
            throw new ArgumentException("Cooling system is not good enough");

        if (_computer.Cpu.PowerConsumptionInWt + _computer.Ram.PowerConsumptionInWt +
            (_computer.DedicatedGpu is null ? 0 : _computer.DedicatedGpu.PowerConsumptionInWt)
            + (_computer.Ssd is null ? 0 : _computer.Ssd.PowerConsumptionInWt) +
            (_computer.Hdd is null ? 0 : _computer.Hdd.PowerConsumptionInWt) > _computer.PowerPack.PeakLoadInWt)
            throw new ArgumentException("Power pack is not good enough");

        return _computer;
    }
}