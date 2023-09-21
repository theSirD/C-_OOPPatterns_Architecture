namespace Itmo.ObjectOrientedProgramming.Lab1.Armors;

public abstract class BaseArmor
{
    public bool IsDestroyed { get; set; }
    protected int MaxHP { get;  set;  }
    protected int CurHP { get; set; }
    public abstract void TakeDamage(int obstacleNumber, int[] obstaclesInEnvironmentList);
}
