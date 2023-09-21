namespace Itmo.ObjectOrientedProgramming.Lab1.Armors;

public class Armor1 : BaseArmor
{
    private const int ObstacleDamageCoefficient = 1;

    public Armor1()
    {
        IsDestroyed = false;
        MaxHP = 100;
        CurHP = 100;
    }

    protected override void TakeDamage(int obstacleType)
    {
        CurHP = MaxHP - (MaxHP * ObstacleDamageCoefficient);
        if (CurHP <= 0) IsDestroyed = true;
    }
}