namespace Itmo.ObjectOrientedProgramming.Lab2;

public class RepoInitializer
{
    public ComponentsRepo? CurrentRepo { get;  set; }

    public void Initialize()
    {
        CurrentRepo?.Add("Intel Iris", new DedicatedGPU("Intel Iris", 2, 2, 2, 2, 2, 2));
    }
}