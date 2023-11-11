namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public class PhotonicDeflector : BaseDeflector
{
    private readonly float[] _obstaclesDamageCoefficients;

    public PhotonicDeflector()
    {
        _obstaclesDamageCoefficients = new float[] { 0f, 0f, 0f, 0.32f };
        IsDestroyed = false;
        MaxHealthPoints = 100;
        CurHealthPoints = 100;
    }
}