namespace Itmo.ObjectOrientedProgramming.Lab1;

public abstract class BaseArmor
{
    protected BaseArmor()
    {
        IsDestroyed = false;
        MaxHP = 100;
        CurHP = 100;
    }

    private bool _isDestroyed;
    public bool IsDestroyed { get; set; }
    protected int MaxHP { get; }
    protected int CurHP { get; set; }
    protected abstract void TakeDamage(int obstacleType);
}
