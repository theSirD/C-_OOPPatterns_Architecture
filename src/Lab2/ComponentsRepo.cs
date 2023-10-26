using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class ComponentsRepo
{
    private static readonly ComponentsRepo Instance = new ComponentsRepo();
    private RepoInitializer _initService;

    private Dictionary<string, BaseRepoItem> _repo;

    private ComponentsRepo()
    {
        _repo = new Dictionary<string, BaseRepoItem>();
        _initService = new RepoInitializer(Current);
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

    public void InitializeRepo()
    {
        _initService.Initialize();
    }
}
