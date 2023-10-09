namespace Itmo.ObjectOrientedProgramming.Lab1.Armors;

public class Armor3 : BaseArmor
{
    private readonly float[] _obstaclesDamageCoefficients;

    public Armor3()
    {
        _obstaclesDamageCoefficients = new float[] { 0.05f, 0.2f, 1f, 1f };
        IsDestroyed = false;
        MaxHP = 100;
        CurHP = 100;
    }
}