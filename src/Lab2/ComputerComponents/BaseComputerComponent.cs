namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents;

public abstract class BaseComputerComponent
{
    protected BaseComputerComponent(string name) => Name = name;

    public string Name { get; init; }

    public BaseComputerComponent? Clone()
    {
        return MemberwiseClone() as BaseComputerComponent;
    }
}