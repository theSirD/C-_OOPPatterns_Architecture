namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Storage;

public class HDD : BaseStorage
{
    public HDD(string name, int capacity, double speed, int consump)
        : base(name, capacity, speed, consump) { }

    public HDD CloneWithNewCapacity(string newName, int capacity)
    {
        return new HDD(newName, capacity, Speed, PowerConsumptionInWt);
    }

    public HDD CloneWithNewSpeedAndPwConsumption(string newName, int speed, int consump)
    {
        return new HDD(newName, CapacityInGb, speed, consump);
    }
}
