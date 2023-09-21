using System;
using Itmo.ObjectOrientedProgramming.Lab1.Armors;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.PulseEngines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships;

public abstract class BaseShip
{
    protected BaseArmor? Armor { get; set; }
    protected BaseDeflector? Deflector { get; set; }
    protected BasePulseEngine? PulseEngine { get; set; }
    protected BaseJumpEngine? JumpEngine { get; set; }

    protected bool IsDestroyed { get; set; }

    protected void TakeDamage(int[] obstaclesInEnvironmentList)
    {
        if (obstaclesInEnvironmentList == null)
            throw new ArgumentNullException(nameof(obstaclesInEnvironmentList), $"is NULL");

        for (int obstacleNumber = 0; obstacleNumber < obstaclesInEnvironmentList.Length; obstacleNumber++)
        {
            if (Deflector != null && !Deflector.IsDestroyed && obstaclesInEnvironmentList[obstacleNumber] != 0) Deflector.TakeDamage(obstacleNumber, obstaclesInEnvironmentList);

            // unnecessary check for Armor is not NULL №1
            if (Armor != null && !Armor.IsDestroyed && obstaclesInEnvironmentList[obstacleNumber] != 0) Armor.TakeDamage(obstacleNumber, obstaclesInEnvironmentList);

            // unnecessary check for Armor is not NULL №2
            if (((Deflector != null && Deflector.IsDestroyed) || Deflector == null) && Armor != null && Armor.IsDestroyed && obstaclesInEnvironmentList[obstacleNumber] != 0)
            {
                IsDestroyed = true;
                break;
            }
        }
    }
}
