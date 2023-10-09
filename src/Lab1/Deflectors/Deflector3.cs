namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public class Deflector3 : BaseDeflector
{
    private readonly float[] _obstaclesDamageCoefficients;

    public Deflector3()
    {
        _obstaclesDamageCoefficients = new float[] { 0.025f, 0.1f, 1f, 1f };
        IsDestroyed = false;
        MaxHP = 100;
        CurHP = 100;
    }
}