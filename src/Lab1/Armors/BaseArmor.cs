namespace Itmo.ObjectOrientedProgramming.Lab1.Armors;

public abstract class BaseArmor
{
    private readonly float[] _obstaclesDamageCoefficients = new float[] { 1f, 1f, 1f, 1f };
    public bool IsDestroyed { get; set; }
    protected int MaxHP { get;  set;  }
    protected int CurHP { get; set; }

    public void TakeDamage(int obstacleNumber)
    {
        CurHP = (int)(MaxHP - (MaxHP * _obstaclesDamageCoefficients[obstacleNumber]));
        if (CurHP < 0) IsDestroyed = true;
    }
}
