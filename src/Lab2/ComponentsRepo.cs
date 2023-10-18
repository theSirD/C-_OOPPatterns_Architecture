using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class ComponentsRepo
{
    private static readonly ComponentsRepo Instance = new ComponentsRepo();

    private Dictionary<string, IComputerComponent<object>> _repo;

    private ComponentsRepo()
    {
        _repo = new Dictionary<string, IComputerComponent<object>>();
    }

    public static ComponentsRepo Current => Instance;

    public void Add(string name, IComputerComponent<object> component)
    {
        _repo.Add(name, component);
    }
}
