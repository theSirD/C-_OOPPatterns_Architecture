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
    protected BaseDeflector? PhotonicDeflector { get; set; }
    protected BasePulseEngine? PulseEngine { get; set; }
    protected BaseJumpEngine? JumpEngine { get; set; }
    protected bool AntiNitrinMediator { get; set; }

    protected bool IsDestroyed { get; set; }

    protected void TakeDamage(int[] obstacles)
    {
        if (obstacles == null)
            throw new ArgumentNullException(nameof(obstacles), $"is NULL");

        foreach (EnumObstacles obstacleName in Enum.GetValues(typeof(EnumObstacles)))
        {
            int obstacleNumber = (int)obstacleName;

            if (obstacleNumber == 2)
            {
                if (AntiNitrinMediator) continue;
            }

            if (obstacleNumber == 3)
            {
                if (((PhotonicDeflector != null && PhotonicDeflector.IsDestroyed) || PhotonicDeflector == null) && obstacles[obstacleNumber] != 0)
                {
                    IsDestroyed = true;
                    break;
                }

                if (PhotonicDeflector != null && !PhotonicDeflector.IsDestroyed && obstacles[obstacleNumber] != 0)
                {
                    PhotonicDeflector.TakeDamage(obstacleNumber);
                    obstacles[obstacleNumber]--;
                }
            }

            if (Deflector != null && !Deflector.IsDestroyed && obstacles[obstacleNumber] != 0)
            {
                Deflector.TakeDamage(obstacleNumber);
                obstacles[obstacleNumber]--;
                continue;
            }

            // unnecessary check for Armor is not NULL №1
            if (Armor != null && !Armor.IsDestroyed && obstacles[obstacleNumber] != 0)
            {
                Armor.TakeDamage(obstacleNumber);
                obstacles[obstacleNumber]--;
                continue;
            }

            // unnecessary check for Armor is not NULL №2
            if (Armor != null && Armor.IsDestroyed && obstacles[obstacleNumber] != 0)
            {
                IsDestroyed = true;
                break;
            }
        }
    }
}
