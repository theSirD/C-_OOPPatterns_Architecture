using Itmo.ObjectOrientedProgramming.Lab1.Armors;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Enums;
using Itmo.ObjectOrientedProgramming.Lab1.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.PulseEngines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships;

public abstract class BaseShip
{
    public BasePulseEngine? PulseEngine { get; protected set; }
    public BaseJumpEngine? JumpEngine { get; protected set; }
    public BaseArmor? Armor { get; set; }
    public BaseDeflector? Deflector { get; set; }
    public BaseDeflector? PhotonicDeflector { get; set; }
    public bool AntiNitrinMediator { get; set; }

    public bool IsDestroyed { get; set; }

    public SegmentResults TakeDamage(int obstacleNumber, int obstaclesAmount)
    {
        while (obstaclesAmount > 0)
        {
            switch (obstacleNumber)
            {
                case 0 or 1:
                    if (Deflector is not { IsDestroyed: true })
                    {
                        Deflector?.TakeDamage(obstacleNumber);
                    }
                    else if (Armor is not { IsDestroyed: true })
                    {
                        Armor?.TakeDamage(obstacleNumber);
                    }
                    else
                    {
                        IsDestroyed = true;
                    }

                    if (IsDestroyed) return SegmentResults.ShipIsDestroyed;

                    break;
                case 2:
                    if (!AntiNitrinMediator)
                    {
                        if (Deflector is not Deflector3 || Deflector?.IsDestroyed == true) return SegmentResults.ShipIsDestroyed;
                        Deflector?.TakeDamage(obstacleNumber);
                    }

                    break;
                case 3:
                    if (PhotonicDeflector is null || PhotonicDeflector.IsDestroyed) return SegmentResults.CrewIsDead;
                    PhotonicDeflector.TakeDamage(obstacleNumber);
                    break;
            }

            obstaclesAmount--;
        }

        return SegmentResults.Success;
    }
}
