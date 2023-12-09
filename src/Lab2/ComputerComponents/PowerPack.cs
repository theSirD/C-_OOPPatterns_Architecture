namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents;

public class PowerPack : BaseRepoItem
{
    public PowerPack(string name, double load)
        : base(name)
    {
        PeakLoadInWt = load;
    }

    public double PeakLoadInWt { get; private set; }
    public override BaseRepoItem Clone()
    {
        return new PowerPack(Name, PeakLoadInWt);
    }
}