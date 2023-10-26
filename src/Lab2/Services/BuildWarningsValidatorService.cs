using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class BuildWarningsValidatorService
{
    private readonly ComputerConfiguration _computer;
    private readonly int powerConsumptionReserve;

    public BuildWarningsValidatorService(ComputerConfiguration computer, int powerConsumptionReserve)
    {
        _computer = computer;
        this.powerConsumptionReserve = powerConsumptionReserve;
    }

    public void CheckTdpOfBuild()
    {
        if (_computer.Cpu?.Tdp > _computer.Cool?.MaxTDP)
            throw new ArgumentException("Disclaimer Of Warranty: Cooling System Is Not Powerful Enough");
    }

    public void CheckPowerConsumptionOfBuild()
    {
        int totalPowerConsumptionInWt = _computer.Cpu?.PowerConsumptionInWt ?? 0 +
            _computer.Ram?.PowerConsumptionInWt ?? 0 +
            (_computer.DedicatedGpu is null ? 0 : _computer.DedicatedGpu.PowerConsumptionInWt) +
            (_computer.Ssd is null ? 0 : _computer.Ssd.PowerConsumptionInWt) +
            (_computer.Hdd is null ? 0 : _computer.Hdd.PowerConsumptionInWt);

        if (totalPowerConsumptionInWt < _computer.PowerPack?.PeakLoadInWt + powerConsumptionReserve &&
            totalPowerConsumptionInWt > _computer.PowerPack?.PeakLoadInWt)
            throw new ArgumentException("Warning: More Powerful Power Pack Is Recommended");
    }
}