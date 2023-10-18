namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Storage;

public abstract class BaseStorage : BaseComputerComponent
{
    protected BaseStorage(string name, int capacity, double speed, int consump)
    : base(name)
    {
        CapacityInGb = capacity;
        Speed = speed;
        PowerConsumptionInWt = consump;
    }

    public int CapacityInGb { get; private init; }
    public double Speed { get; private init; }
    public int PowerConsumptionInWt { get; private init; }
}