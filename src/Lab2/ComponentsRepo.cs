using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class ComponentsRepo
{
    private static readonly ComponentsRepo Instance = new ComponentsRepo();

    private Dictionary<string, ComputerComponent> _repo;

    private ComponentsRepo()
    {
        _repo = new Dictionary<string, ComputerComponent>();
    }

    public static ComponentsRepo Current => Instance;

    public void Add(string name, ComputerComponent component)
    {
        _repo.Add(name, component);
    }
}
