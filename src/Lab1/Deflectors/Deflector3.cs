using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public class Deflector3 : BaseDeflector
{
    private const float AsteroidDamageCoefficient = 0.025f;
    private const float MeteorDamageCoefficient = 0.1f;
    private const float SpaceWhaleDamageCoefficient = 1;

    public Deflector3()
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
            if (obstacleNumber == 2) CurHP = (int)(MaxHP - (MaxHP * SpaceWhaleDamageCoefficient));
            if (CurHP <= 0) IsDestroyed = true;
        }
    }
}