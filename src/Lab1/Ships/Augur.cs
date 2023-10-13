using Itmo.ObjectOrientedProgramming.Lab1.Armors;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.PulseEngines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships;

public class Augur : BaseShip
{
    public Augur()
    {
        PulseEngine = new PulseEngineE();
        JumpEngine = new JumpEngineA();
        Deflector = new Deflector3();
        Armor = new Armor3();
    }
}