namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public class Deflector1 : BaseDeflector
{
    private readonly float[] _obstaclesDamageCoefficients;

    public Deflector1()
    {
        _obstaclesDamageCoefficients = new float[] { 0.5f, 1f, 1f, 1f };
        IsDestroyed = false;
        MaxHealthPoints = 100;
        CurHealthPoints = 100;
    }
}