namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents;

public class PowerPack : BaseComputerComponent
{
    public PowerPack(string name, int load)
        : base(name)
    {
        PeakLoadInWt = load;
    }

    public double PeakLoadInWt { get; private set; }
}