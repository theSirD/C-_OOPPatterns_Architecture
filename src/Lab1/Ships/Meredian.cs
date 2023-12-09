using Itmo.ObjectOrientedProgramming.Lab1.Armors;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.PulseEngines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships;

public class Meredian : BaseShip
{
    public Meredian()
    {
        PulseEngine = new PulseEngineE();
        AntiNitrinMediator = true;
        Deflector = new Deflector2();
        Armor = new Armor2();
    }
}