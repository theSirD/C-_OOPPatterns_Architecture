namespace Itmo.ObjectOrientedProgramming.Lab1.Armors;

public class Armor1 : BaseArmor
{
    private readonly float[] _obstaclesDamageCoefficients;

    public Armor1()
    {
        _obstaclesDamageCoefficients = new float[] { 1f, 1f, 1f, 1f };
        IsDestroyed = false;
        MaxHealthPoints = 100;
        CurHealthPoints = 100;
    }
}