namespace Itmo.ObjectOrientedProgramming.Lab2;

public static class Program
{
    public static void Main()
    {
        var gpu = new DedicatedGPU(2, 2, 2, 2, 2, 2);

        // gpu.GetInfo();
        DedicatedGPU? nGPU = gpu.Clone();
        if (nGPU is not null)
             nGPU.Width = 5;

        // nGPU?.GetInfo();
    }
}