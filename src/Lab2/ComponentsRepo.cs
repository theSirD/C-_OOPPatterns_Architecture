using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class ComponentsRepo
{
    private static readonly ComponentsRepo Instance = new ComponentsRepo();

    private Dictionary<string, BaseComputerComponent> _repo;

    private ComponentsRepo()
    {
        _repo = new Dictionary<string, BaseComputerComponent>();
    }

    public static ComponentsRepo Current => Instance;

    public void Add(string name, BaseComputerComponent component)
    {
        _repo.Add(name, component);
    }
}
