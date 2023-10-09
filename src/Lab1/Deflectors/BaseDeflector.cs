namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public abstract class BaseDeflector
{
    public bool IsDestroyed { get; set; }
    protected int MaxHP { get;  set;  }
    protected int CurHP { get; set; }

    public abstract void TakeDamage(int obstacleNumber);
}