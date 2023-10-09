namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public class PhotonicDeflector : BaseDeflector
{
    private readonly float[] _obstaclesDamageCoefficients;

    public PhotonicDeflector()
    {
        _obstaclesDamageCoefficients = new float[] { 0f, 0f, 0.34f, 0f };
        IsDestroyed = false;
        MaxHP = 100;
        CurHP = 100;
    }
}