namespace Itmo.ObjectOrientedProgramming.Lab1.Armors;

public class Armor2 : BaseArmor
{
    private readonly float[] _obstaclesDamageCoefficients = new float[] { 0.2f, 0.5f, 1f, 1f };
    public Armor2()
    {
        IsDestroyed = false;
        MaxHP = 100;
        CurHP = 100;
    }

    public override void TakeDamage(int obstacleNumber)
    {
        CurHP = (int)(MaxHP - (MaxHP * _obstaclesDamageCoefficients[obstacleNumber]));
        if (CurHP < 0) IsDestroyed = true;
    }
}