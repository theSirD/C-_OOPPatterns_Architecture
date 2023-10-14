namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public abstract class BaseDeflector
{
    private readonly float[] _obstaclesDamageCoefficients = new float[] { 1f, 1f, 1f, 0.32f };
    public bool IsDestroyed { get; set; }
    protected int MaxHealthPoints { get;  set;  }
    protected int CurHealthPoints { get; set; }

    public void TakeDamage(int obstacleNumber)
    {
        CurHealthPoints = (int)(MaxHealthPoints - (MaxHealthPoints * _obstaclesDamageCoefficients[obstacleNumber]));
        if (CurHealthPoints <= 0) IsDestroyed = true;
    }
}