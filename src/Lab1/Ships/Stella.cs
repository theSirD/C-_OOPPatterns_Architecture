using Itmo.ObjectOrientedProgramming.Lab1.Armors;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.PulseEngines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships;

public class Stella : BaseShip
{
    public Stella()
    {
        PulseEngine = new PulseEngineC();
        JumpEngine = new JumpEngineO();
        Deflector = new Deflector1();
        Armor = new Armor1();
    }
}