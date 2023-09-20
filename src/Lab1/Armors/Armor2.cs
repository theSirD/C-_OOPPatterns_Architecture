namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Armor2 : BaseArmor
{
    private const float AsteroidDamageCoefficient = 0.2f;
    private const float MeteorDamageCoefficient = 0.5f;

    protected override void TakeDamage(int obstacleType)
    {
        if (obstacleType == 0) CurHP = (int)(MaxHP - (MaxHP * AsteroidDamageCoefficient));
        if (obstacleType == 1) CurHP = (int)(MaxHP - (MaxHP * MeteorDamageCoefficient));
        if (CurHP <= 0) IsDestroyed = true;
    }
}