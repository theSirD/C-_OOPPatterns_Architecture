namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public class Deflector3 : BaseDeflector
{
    private readonly float[] _obstaclesDamageCoefficients = new float[] { 0.025f, 0.1f, 1f, 1f };

    public Deflector3()
    {
        IsDestroyed = false;
        MaxHP = 100;
        CurHP = 100;
    }

    public override void TakeDamage(int obstacleNumber)
    {
        CurHP = (int)(MaxHP - (MaxHP * _obstaclesDamageCoefficients[obstacleNumber]));
        if (CurHP < 0) IsDestroyed = true;
    }
}