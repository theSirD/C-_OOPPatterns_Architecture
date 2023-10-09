namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public class PhotonicDeflector : BaseDeflector
{
    private readonly float[] _obstaclesDamageCoefficients = new float[] { 0f, 0f, 0.34f, 0f };

    public PhotonicDeflector()
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