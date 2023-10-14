using Itmo.ObjectOrientedProgramming.Lab1.Armors;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.PulseEngines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships;

public class Vaclas : BaseShip
{
    public Vaclas()
    {
        PulseEngine = new PulseEngineE();
        JumpEngine = new JumpEngineG();
        Deflector = new Deflector1();
        Armor = new Armor2();
    }
}