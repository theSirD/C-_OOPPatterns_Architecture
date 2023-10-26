using System;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Storage;

public class SSD : BaseStorage
{
    public SSD(string name, int capacity, double speed, int consump, SSDConnectionType connectionType)
    : base(name, capacity, speed, consump)
    {
        ConnectionType = connectionType;
    }

    public SSDConnectionType ConnectionType { get; private init; }
    public void CanBePlaced(ComputerConfiguration computer)
    {
        if (computer?.MotherBoard is null)
            throw new ArgumentException("Install mother board first");

        if (ConnectionType == SSDConnectionType.PCIE)
        {
            if (computer.MotherBoard.PciLinesAmount < computer.MotherBoard.CurPciLinesAmount + 1)
                throw new ArgumentException("Mother board does not have enough PCIE lines");
        }
        else
        {
            if (computer.MotherBoard.SataPortsAmount < computer.MotherBoard.CurSataPortsAmount + 1)
                throw new ArgumentException("Mother board does not have enough SATA ports");
        }
    }

    public SSD CloneWithNewCapacity(string newName, int capacity)
    {
        return new SSD(newName, capacity, Speed, PowerConsumptionInWt, ConnectionType);
    }

    public SSD CloneWithNewSpeedAndPwConsumption(string newName, int speed, int consump)
    {
        return new SSD(newName, CapacityInGb, speed, consump, ConnectionType);
    }

    public SSD CloneWithNewConnectionType(string newName, SSDConnectionType connectionType)
    {
        return new SSD(newName, CapacityInGb, Speed, PowerConsumptionInWt, connectionType);
    }
}