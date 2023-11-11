namespace Itmo.ObjectOrientedProgramming.Lab2;

public abstract class BaseRepoItem
{
    protected BaseRepoItem(string name) => Name = name;

    public string Name { get; init; }

    public abstract BaseRepoItem Clone();
}