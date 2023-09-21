using System;

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

    public override void TakeDamage(int obstacleNumber, int[] obstaclesInEnvironmentList)
    {
        if (obstaclesInEnvironmentList == null)
            throw new ArgumentNullException(nameof(obstaclesInEnvironmentList), $"is NULL");

        // array needs to be passed by reference
        while (CurHP > 0 && obstaclesInEnvironmentList[obstacleNumber] != 0)
        {
            if (obstacleNumber == 0) CurHP = (int)(MaxHP - (MaxHP * ObstacleDamageCoefficient));
            if (obstacleNumber == 1) CurHP = (int)(MaxHP - (MaxHP * ObstacleDamageCoefficient));
            if (CurHP <= 0) IsDestroyed = true;
        }
    }
}