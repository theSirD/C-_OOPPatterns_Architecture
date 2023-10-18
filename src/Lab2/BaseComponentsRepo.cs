using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class BaseComponentsRepo
{
    private static readonly BaseComponentsRepo Instance = new BaseComponentsRepo();

    private Dictionary<string, BaseComputerComponent> _repo;

    private BaseComponentsRepo()
    {
        _repo = new Dictionary<string, BaseComputerComponent>();
    }

    public static BaseComponentsRepo Current => Instance;

    public void Add(string name, BaseComputerComponent component)
    {
        _repo.Add(name, component);
    }
}
