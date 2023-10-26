namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents;

public class XMPProfile : BaseComputerComponent
{
    public XMPProfile(string name, double voltage, double freq, string timing)
    : base(name)
    {
        Voltage = voltage;
        Frequency = freq;
        Timing = timing;
    }

    public double Voltage { get; private init; }
    public double Frequency { get; private init; }
    public string Timing { get; private init; }

    public XMPProfile CloneWithNewFrequency(string newName, double freq)
    {
        return new XMPProfile(newName, Voltage, freq, Timing);
    }
}