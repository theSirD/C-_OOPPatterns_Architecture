namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Armor1 : BaseArmor
{
    private const int ObstacleDamageCoefficient = 1;

    protected override void TakeDamage(int obstacleType)
    {
        CurHP = MaxHP - (MaxHP * ObstacleDamageCoefficient);
        if (CurHP <= 0) IsDestroyed = true;
    }
}