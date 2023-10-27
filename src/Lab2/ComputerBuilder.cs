using System;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Responses;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Storage;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class ComputerBuilder
{
    private ComponentsRepo _repo = ComponentsRepo.Instance;
    private ComputerConfiguration _computer;
    private BuildErrorsValidatorService _errorsValidator;
    private BuildWarningsValidatorService _warningsValidator;

    public ComputerBuilder(string name)
    {
        _computer = new ComputerConfiguration(name);
        _errorsValidator = new BuildErrorsValidatorService(_computer, 20);
        _warningsValidator = new BuildWarningsValidatorService(_computer, 20);
    }

    public ComputerBuilder(ComputerConfiguration computer)
    {
        if (computer is null)
            throw new ArgumentException("Recieved null instead of computer");
        _computer = (ComputerConfiguration)computer.Clone();
        _errorsValidator = new BuildErrorsValidatorService(_computer, 20);
        _warningsValidator = new BuildWarningsValidatorService(_computer, 20);
    }

    public void Reset(string name)
    {
        _computer = new ComputerConfiguration(name);
    }

    public void WithMotherBoard(string name)
    {
        _computer.MotherBoard = (MotherBoard)_repo.Get(name).Clone();
    }

    public void WithComputerCase(string name)
    {
        _computer.ComputerCase = (PCCase)_repo.Get(name).Clone();
    }

    public void WithBios(string name)
    {
        _computer.Bios = (BIOS)_repo.Get(name).Clone();
    }

    public void WithPowerPack(string name)
    {
        _computer.PowerPack = (PowerPack)_repo.Get(name).Clone();
    }

    public void WithXmp(string name)
    {
        _computer.Xmp = (XMPProfile)_repo.Get(name).Clone();
    }

    public void WithCool(string name)
    {
        var curCool = (CoolingSystem)_repo.Get(name).Clone();

        curCool.CanBePlaced(_computer);

        _computer.Cool = curCool;
    }

    public void WithCpu(string name)
    {
        var curCpu = (CPU)_repo.Get(name).Clone();

        curCpu.CanBePlaced(_computer);

        _computer.Cpu = curCpu;
    }

    public void WithRam(string name)
    {
        var curRam = (RAM)_repo.Get(name).Clone();

        curRam.CanBePlaced(_computer);

        _computer.Ram = curRam;
    }

    public void WithWifi(string name)
    {
        var curNetworkModule = (NetworkModule)_repo.Get(name).Clone();

        curNetworkModule.CanBePlaced(_computer);

        _computer.Wifi = curNetworkModule;
        if (_computer.MotherBoard is not null) _computer.MotherBoard.CurPciLinesAmount++;
    }

    public void WithDedicatedGpu(string name)
    {
        var curGpu = (DedicatedGPU)_repo.Get(name).Clone();

        curGpu.CanBePlaced(_computer);

        _computer.DedicatedGpu = curGpu;
        if (_computer.MotherBoard is not null) _computer.MotherBoard.CurPciLinesAmount++;
    }

    public void WithSsd(string name)
    {
        var curSsd = (SSD)_repo.Get(name).Clone();

        curSsd.CanBePlaced(_computer);

        _computer.Ssd = curSsd;
        if (_computer.MotherBoard is not null)
        {
            if (curSsd.ConnectionType == SSDConnectionType.PCIE) _computer.MotherBoard.CurPciLinesAmount++;
            else _computer.MotherBoard.CurSataPortsAmount++;
        }
    }

    public void WithHdd(string name)
    {
        _computer.Hdd = (HDD)_repo.Get(name).Clone();
    }

    public BuildResponse Build()
    {
        try
        {
            _errorsValidator.CheckIfBuildHasStorage();
            _errorsValidator.CheckIfBuildHasRequiredComponents();
            _errorsValidator.CheckForCaseAndMotherBoardCompatibility();
            _errorsValidator.CheckIfBuildHasGpu();
            _errorsValidator.CheckIfComponentsFitCase();
            _errorsValidator.CheckPowerConsumptionOfBuild();

            _warningsValidator.CheckTdpOfBuild();
            _warningsValidator.CheckPowerConsumptionOfBuild();
        }
        catch (ArgumentException ex)
        {
            return new BuildResponse(_computer, ex.Message);
        }

        return new BuildResponse(_computer, "Success");
    }
}