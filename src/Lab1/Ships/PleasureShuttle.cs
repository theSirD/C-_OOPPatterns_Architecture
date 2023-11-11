using Itmo.ObjectOrientedProgramming.Lab1.Armors;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.PulseEngines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships;

public class PleasureShuttle : BaseShip
{
    public PleasureShuttle()
    {
        PulseEngine = new PulseEngineC();
        Armor = new Armor1();
        AntiNitrinMediator = true;
        Deflector = new Deflector2();
        Armor = new Armor2();
    }
}