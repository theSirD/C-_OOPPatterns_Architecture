namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Storage;

public class SSD : BaseStorage
{
    public SSD(string name, int capacity, double speed, int consump, string connectionType)
    : base(name, capacity, speed, consump)
    {
        ConnectionType = connectionType;
    }

    public string? ConnectionType { get; private init; }
}