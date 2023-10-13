using Itmo.ObjectOrientedProgramming.Lab1.PulseEngines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships;

public class Meredian : BaseShip
{
    public Meredian()
    {
        PulseEngine = new PulseEngineE();
    }
}