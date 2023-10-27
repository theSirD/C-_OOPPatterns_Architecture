using System;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class BuildErrorsValidatorService
{
    private readonly ComputerConfiguration _computer;
    private readonly int _powerConsumptionReserve;

    public BuildErrorsValidatorService(ComputerConfiguration computer, int powerConsumptionReserve)
    {
        _computer = computer;
        _powerConsumptionReserve = powerConsumptionReserve;
    }

    public void CheckIfBuildHasStorage()
    {
        if (_computer.Hdd is null && _computer.Ssd is null)
            throw new ArgumentException("Configuration does not have a storage");
    }

    public void CheckIfBuildHasRequiredComponents()
    {
        if (_computer.MotherBoard is null || _computer.Cpu is null || _computer.Bios is null ||
            _computer.Cool is null || _computer.Ram is null || _computer.PowerPack is null ||
            _computer.ComputerCase is null)
            throw new ArgumentException("Configuration does not have one (or more) required components");
    }

    public void CheckForCaseAndMotherBoardCompatibility()
    {
        switch (_computer.ComputerCase?.SupportedFormOfMotherBoard)
        {
            case MotherBoardFormFactors.MicroATX:
                if (_computer.MotherBoard?.FormFactor == MotherBoardFormFactors.ATX)
                    throw new ArgumentException("Computer case does not support form factor of mother boards chosen");
                break;

            case MotherBoardFormFactors.MiniATX:
                if (_computer.MotherBoard?.FormFactor == MotherBoardFormFactors.ATX || _computer.MotherBoard?.FormFactor == MotherBoardFormFactors.MicroATX)
                    throw new ArgumentException("Computer case does not support form factor of mother boards chosen");
                break;

            case MotherBoardFormFactors.NanoATX:
                if (_computer.MotherBoard?.FormFactor == MotherBoardFormFactors.ATX ||
                    _computer.MotherBoard?.FormFactor == MotherBoardFormFactors.MicroATX ||
                    _computer.MotherBoard?.FormFactor == MotherBoardFormFactors.NanoATX)
                    throw new ArgumentException("Computer case does not support form factor of mother boards chosen");
                break;
        }
    }

    public void CheckIfBuildHasGpu()
    {
        if (_computer.Cpu is null)
            throw new ArgumentException("Configuration does not have a CPU");
        {
            if (!_computer.Cpu.HasGpu && _computer.DedicatedGpu is null)
                throw new ArgumentException("Configuration does not have a GPU");
        }
    }

    public void CheckIfComponentsFitCase()
    {
        if (_computer.Cool?.WidthInSm + (_computer.DedicatedGpu is null ? 0 : _computer.DedicatedGpu.WidthInSm) > _computer.ComputerCase?.WidthInSm)
            throw new ArgumentException("Components are to wide for this computer case");

        if (_computer.Cool?.HeightInSm + (_computer.DedicatedGpu is null ? 0 : _computer.DedicatedGpu.HeightInSm) > _computer.ComputerCase?.HeightInSm)
            throw new ArgumentException("Components are to tall for this computer case");
    }

    public void CheckPowerConsumptionOfBuild()
    {
        int totalPowerConsumptionInWt = _computer.Cpu?.PowerConsumptionInWt ?? 0 +
            _computer.Ram?.PowerConsumptionInWt ?? 0 +
            (_computer.DedicatedGpu is null ? 0 : _computer.DedicatedGpu.PowerConsumptionInWt) +
            (_computer.Ssd is null ? 0 : _computer.Ssd.PowerConsumptionInWt) +
            (_computer.Hdd is null ? 0 : _computer.Hdd.PowerConsumptionInWt);

        if (totalPowerConsumptionInWt > _computer.PowerPack?.PeakLoadInWt + _powerConsumptionReserve &&
            totalPowerConsumptionInWt > _computer.PowerPack?.PeakLoadInWt)
            throw new ArgumentException("More powerful PowerPack Is required");
    }
}