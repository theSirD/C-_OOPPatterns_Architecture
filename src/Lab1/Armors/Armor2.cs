namespace Itmo.ObjectOrientedProgramming.Lab1.Armors;

public class Armor2 : BaseArmor
{
    private readonly float[] _obstaclesDamageCoefficients;
    public Armor2()
    {
        _obstaclesDamageCoefficients = new float[] { 0.2f, 0.5f, 1f, 1f };
        IsDestroyed = false;
        MaxHP = 100;
        CurHP = 100;
    }
}