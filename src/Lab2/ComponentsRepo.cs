using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class ComponentsRepo
{
    private static readonly ComponentsRepo Instance = new ComponentsRepo();

    private Dictionary<string, BaseRepoItem> _repo;

    private ComponentsRepo()
    {
        _repo = new Dictionary<string, BaseRepoItem>();
    }

    public static ComponentsRepo Current => Instance;

    public void Add(string name, BaseRepoItem component)
    {
        if (_repo.ContainsKey(name))
            throw new ArgumentException("Item with this name is already in repo");
        _repo.Add(name, component);
    }

    public BaseRepoItem Get(string name)
    {
        return _repo[name];
    }
}
