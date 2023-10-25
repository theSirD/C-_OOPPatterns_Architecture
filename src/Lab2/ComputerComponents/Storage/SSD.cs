using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Storage;

public class SSD : BaseStorage
{
    public SSD(string name, int capacity, double speed, int consump, string connectionType)
    : base(name, capacity, speed, consump)
    {
        ConnectionType = connectionType;
    }

    public string? ConnectionType { get; private init; }
    public override void CanBePlaced(ComputerConfiguration computer)
    {
        if (computer?.MotherBoard is null)
            throw new ArgumentException("Install mother board first");

        if (ConnectionType == "PCIE")
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
}