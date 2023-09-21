using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Armors;

public class Armor3 : BaseArmor
{
    private const float AsteroidDamageCoefficient = 0.05f;
    private const float MeteorDamageCoefficient = 0.2f;

    public Armor3()
    {
        IsDestroyed = false;
        MaxHP = 100;
        CurHP = 100;
    }

    public override void TakeDamage(int obstacleNumber, int[] obstaclesInEnvironmentList)
    {
        if (obstaclesInEnvironmentList == null)
            throw new ArgumentNullException(nameof(obstaclesInEnvironmentList), $"is NULL");

        // array needs to be passed by reference
        while (CurHP > 0 && obstaclesInEnvironmentList[obstacleNumber] != 0)
        {
            if (obstacleNumber == 0) CurHP = (int)(MaxHP - (MaxHP * AsteroidDamageCoefficient));
            if (obstacleNumber == 1) CurHP = (int)(MaxHP - (MaxHP * MeteorDamageCoefficient));
            if (CurHP <= 0) IsDestroyed = true;
        }
    }
}