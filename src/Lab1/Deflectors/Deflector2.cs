namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public class Deflector2 : BaseDeflector
{
    private readonly float[] _obstaclesDamageCoefficients;

    public Deflector2()
    {
        _obstaclesDamageCoefficients = new float[] { 0.1f, 0.34f, 1f, 1f };
        IsDestroyed = false;
        MaxHealthPoints = 100;
        CurHealthPoints = 100;
    }
}